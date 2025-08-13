// =====================================================================================
// Autor: Raul Ortega Acuña
// Archivo: CustomerController.cs
// Solución: Proyecto_Final_Progra_6
// Proyecto: Proyecto_Final_Progra_6.Server
// Ruta: Proyecto_Final_Progra_6\Proyecto_Final_Progra_6.Server\Controllers\CustomerController.cs
//
// Descripción o propósito del archivo:
// Controlador para la gestión de clientes en la Librería Universidad. Incluye endpoints
// para CRUD de clientes, con protección por roles, validaciones y manejo de errores.
//
// Historial de cambios:
// 1. 04/08/2025 - Se agregó protección por roles y validaciones en todos los endpoints.
//                 Se tradujeron comentarios y se mejoró el manejo de errores.
//                 Se actualizó el encabezado y se agregaron comentarios descriptivos.
// =====================================================================================

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_Progra_6.Core.Services;
using Proyecto_Final_Progra_6.Core.Services.Shop;
using Proyecto_Final_Progra_6.Server.Services.Email;
using Proyecto_Final_Progra_6.Server.ViewModels.Shop;
using Proyecto_Final_Progra_6.Core.Models.Account;
using Proyecto_Final_Progra_6.Core.Services.Account;
using Proyecto_Final_Progra_6.Server.ViewModels.Account;

namespace Proyecto_Final_Progra_6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSender;
        private readonly ICustomerService _customerService;
        private readonly IUserAccountService _userAccountService;

        public CustomerController(IMapper mapper, ILogger<CustomerController> logger, IEmailSender emailSender,
            ICustomerService customerService, IUserAccountService userAccountService)
        {
            _mapper = mapper;
            _logger = logger;
            _emailSender = emailSender;
            _customerService = customerService;
            _userAccountService = userAccountService;
        }

        // ======================================================== INICIO - OBTENER TODOS LOS CLIENTES ========================================================
        // Devuelve la lista completa de clientes registrados. Solo para administradores.
        // ***************************************************************************************************************
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            var allCustomers = _customerService.GetAllCustomersData();
            return Ok(_mapper.Map<IEnumerable<CustomerVM>>(allCustomers));
        }
        // ======================================================== FIN - OBTENER TODOS LOS CLIENTES ===========================================================

        // ======================================================== INICIO - OBTENER CLIENTE POR ID ============================================================
        // Devuelve los datos de un cliente específico por su ID. Solo para administradores.
        // ***************************************************************************************************************
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound($"Cliente con ID {id} no encontrado.");
            return Ok(_mapper.Map<CustomerVM>(customer));
        }
        // ======================================================== FIN - OBTENER CLIENTE POR ID ==============================================================

        // ======================================================== INICIO - CREAR NUEVO CLIENTE ==============================================================
        // Crea un nuevo cliente con los datos proporcionados. Público (registro).
        // ***************************************************************************************************************
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerVM value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 1. Crear usuario de autenticación
            var user = new UserEditVM
            {
                UserName = value.Email ?? value.Name ?? Guid.NewGuid().ToString(),
                Email = value.Email ?? string.Empty,
                FullName = value.Name,
                PhoneNumber = value.PhoneNumber,
                IsEnabled = true,
                Roles = new[] { "Cliente" },
                NewPassword = value.PhoneNumber ?? "Cliente123!" // O pedir contraseña en el registro real
            };

            var appUser = _mapper.Map<ApplicationUser>(user);
            var result = await _userAccountService.CreateUserAsync(appUser, user.Roles!, user.NewPassword!);

            if (!result.Succeeded)
            {
                foreach (var err in result.Errors)
                    ModelState.AddModelError("User", err);
                return BadRequest(ModelState);
            }

            // 2. Crear entidad cliente
            var customer = _mapper.Map<Proyecto_Final_Progra_6.Core.Models.Shop.Customer>(value);
            var created = _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, _mapper.Map<CustomerVM>(created));
        }
        // ======================================================== FIN - CREAR NUEVO CLIENTE ================================================================

        // ======================================================== INICIO - ACTUALIZAR CLIENTE ===============================================================
        // Actualiza los datos de un cliente existente. Solo para administradores.
        // ***************************************************************************************************************
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerVM value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customer = _mapper.Map<Proyecto_Final_Progra_6.Core.Models.Shop.Customer>(value);
            var updated = _customerService.UpdateCustomer(id, customer);
            if (updated == null)
                return NotFound($"Cliente con ID {id} no encontrado.");
            return Ok(_mapper.Map<CustomerVM>(updated));
        }
        // ======================================================== FIN - ACTUALIZAR CLIENTE ==================================================================

        // ======================================================== INICIO - ELIMINAR CLIENTE ==================================================================
        // Elimina un cliente por su ID. Solo para administradores.
        // ***************************************************************************************************************
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _customerService.DeleteCustomer(id);
            if (!deleted)
                return NotFound($"Cliente con ID {id} no encontrado.");
            return NoContent();
        }
        // ======================================================== FIN - ELIMINAR CLIENTE =====================================================================
    }
}
