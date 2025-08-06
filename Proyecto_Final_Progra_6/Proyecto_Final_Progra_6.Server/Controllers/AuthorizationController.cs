// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: AuthorizationController.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Server
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Server\Controllers\AuthorizationController.cs
//
// Descripción o propósito del archivo:
// Controlador para la autorización y emisión de tokens OpenID Connect en la aplicación.
// Gestiona el flujo de autenticación por contraseña y refresh token, validando usuarios
// y generando los claims necesarios para la identidad y acceso.
//
// Historial de cambios:
// 1. 27/04/2024 - Migración y adaptación del controlador de autorización a Libreria Universidad.
//                 Se tradujeron comentarios y se eliminaron referencias a QuickApp y ebenmonney.
//                 Se agregaron encabezados de sección y pie de sección según estándar.
//
// Alertas Críticas:
// - 27/04/2024 - Se recomienda revisar el manejo de excepciones y agregar logging detallado
//                para auditoría de fallos de autenticación.
// - 27/04/2024 - Verificar que las URLs y referencias externas apunten a la documentación oficial
//                o al repositorio del proyecto: https://github.com/RaulOA/Libreria-Universidad
// =====================================================================================

using System.Security.Claims;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using Proyecto_Final_Progra_6.Core.Models.Account;
using Proyecto_Final_Progra_6.Core.Services.Account;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Proyecto_Final_Progra_6.Server.Controllers
{
    // ======================================================== INICIO - CONTROLADOR DE AUTORIZACIÓN ========================================================
    // Controlador principal para la gestión de autenticación y autorización OpenID Connect.
    // ***************************************************************************************************************
    public class AuthorizationController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorizationController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("~/connect/token")]
        [Produces("application/json")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Exchange()
        {
            // Obtiene la solicitud OpenID Connect del contexto HTTP
            var request = HttpContext.GetOpenIddictServerRequest()
                ?? throw new InvalidOperationException("No se pudo obtener la solicitud OpenID Connect.");

            if (request.IsPasswordGrantType())
            {
                // Validación de usuario y contraseña no vacíos
                if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                    return GetForbidResult("El nombre de usuario o la contraseña no pueden estar vacíos.");

                // Búsqueda del usuario por nombre o correo electrónico
                var user = await _userManager.FindByNameAsync(request.Username)
                    ?? await _userManager.FindByEmailAsync(request.Username);

                if (user == null)
                    return GetForbidResult("Verifique que su nombre de usuario y contraseña sean correctos.");

                if (!user.IsEnabled)
                    return GetForbidResult("La cuenta de usuario especificada está deshabilitada.");

                var result =
                    await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);

                if (result.IsLockedOut)
                    return GetForbidResult("La cuenta de usuario especificada ha sido suspendida.");

                if (result.IsNotAllowed)
                    return GetForbidResult("El usuario especificado no tiene permitido iniciar sesión.");

                if (!result.Succeeded)
                    return GetForbidResult("Verifique que su nombre de usuario y contraseña sean correctos.");

                // Genera el principal con los claims y scopes correspondientes
                var principal = await CreateClaimsPrincipalAsync(user, request.GetScopes());

                return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }
            else if (request.IsRefreshTokenGrantType())
            {
                // Autenticación mediante refresh token
                var result =
                    await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

                var userId = result?.Principal?.GetClaim(Claims.Subject);
                var user = userId != null ? await _userManager.FindByIdAsync(userId) : null;

                if (user == null)
                    return GetForbidResult("El refresh token ya no es válido.");

                if (!user.IsEnabled)
                    return GetForbidResult("La cuenta de usuario especificada está deshabilitada.");

                if (!await _signInManager.CanSignInAsync(user))
                    return GetForbidResult("El usuario ya no tiene permitido iniciar sesión.");

                var scopes = request.GetScopes();
                if (scopes.Length == 0 && result?.Principal != null)
                    scopes = result.Principal.GetScopes();

                // Recrea el principal de claims en caso de que hayan cambiado desde la emisión del refresh token
                var principal = await CreateClaimsPrincipalAsync(user, scopes);

                return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            throw new InvalidOperationException($"El tipo de grant especificado \"{request.GrantType}\" no es soportado.");
        }

        // Método auxiliar para devolver un resultado de prohibición con mensaje de error personalizado
        private ForbidResult GetForbidResult(string errorDescription, string error = Errors.InvalidGrant)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string?>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = error,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = errorDescription
            });

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        // Genera el ClaimsPrincipal con los claims personalizados y scopes para el usuario autenticado
        private async Task<ClaimsPrincipal> CreateClaimsPrincipalAsync(ApplicationUser user, IEnumerable<string> scopes)
        {
            var principal = await _signInManager.CreateUserPrincipalAsync(user);
            principal.SetScopes(scopes);

            var identity = principal.Identity as ClaimsIdentity
                ?? throw new InvalidOperationException("La identidad del ClaimsPrincipal es nula.");

            if (user.JobTitle != null) identity.SetClaim(CustomClaims.JobTitle, user.JobTitle);
            if (user.FullName != null) identity.SetClaim(CustomClaims.FullName, user.FullName);
            if (user.Configuration != null) identity.SetClaim(CustomClaims.Configuration, user.Configuration);

            principal.SetDestinations(GetDestinations);

            return principal;
        }

        // Define los destinos de los claims según el scope y tipo de claim
        private static IEnumerable<string> GetDestinations(Claim claim)
        {
            if (claim.Subject == null)
                throw new InvalidOperationException("El Subject del Claim es nulo.");

            switch (claim.Type)
            {
                case Claims.Name:
                    if (claim.Subject.HasScope(Scopes.Profile))
                        yield return Destinations.IdentityToken;

                    yield break;

                case Claims.Email:
                    if (claim.Subject.HasScope(Scopes.Email))
                        yield return Destinations.IdentityToken;

                    yield break;

                case CustomClaims.JobTitle:
                    if (claim.Subject.HasScope(Scopes.Profile))
                        yield return Destinations.IdentityToken;

                    yield break;

                case CustomClaims.FullName:
                    if (claim.Subject.HasScope(Scopes.Profile))
                        yield return Destinations.IdentityToken;

                    yield break;

                case CustomClaims.Configuration:
                    if (claim.Subject.HasScope(Scopes.Profile))
                        yield return Destinations.IdentityToken;

                    yield break;

                case Claims.Role:
                    yield return Destinations.AccessToken;

                    if (claim.Subject.HasScope(Scopes.Roles))
                        yield return Destinations.IdentityToken;

                    yield break;

                case CustomClaims.Permission:
                    yield return Destinations.AccessToken;

                    if (claim.Subject.HasScope(Scopes.Roles))
                        yield return Destinations.IdentityToken;

                    yield break;

                // IdentityOptions.ClaimsIdentity.SecurityStampClaimType
                case "AspNet.Identity.SecurityStamp":
                    // Nunca incluir el security stamp en los tokens de acceso o identidad, ya que es un valor secreto.
                    yield break;

                default:
                    yield return Destinations.AccessToken;
                    yield break;
            }
        }
    }
    // ======================================================== FIN - CONTROLADOR DE AUTORIZACIÓN =========================================================
}
