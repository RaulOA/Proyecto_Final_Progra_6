﻿// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using System.Security.Claims;
using Proyecto_Final_Progra_6.Core.Services.Account;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Proyecto_Final_Progra_6.Server.Services
{
    public class UserIdAccessor(IHttpContextAccessor httpContextAccessor) : IUserIdAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string? GetCurrentUserId() => _httpContextAccessor.HttpContext?.User.FindFirstValue(Claims.Subject);
    }

    public class SystemUserIdAccessor : IUserIdAccessor
    {
        private readonly string? id;

        private SystemUserIdAccessor(string? id) => this.id = id;

        public string? GetCurrentUserId() => id;

        public static SystemUserIdAccessor GetNewAccessor(string? id = "SYSTEM") => new(id);
    }
}
