// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Proyecto_Final_Progra_6.Core.Models.Account;
using Proyecto_Final_Progra_6.Core.Models.Shop;
using Proyecto_Final_Progra_6.Core.Services.Account;
using Proyecto_Final_Progra_6.Server.ViewModels.Account;
using Proyecto_Final_Progra_6.Server.ViewModels.Shop;

namespace Proyecto_Final_Progra_6.Server.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserVM>()
                   .ForMember(d => d.Roles, map => map.Ignore());
            CreateMap<UserVM, ApplicationUser>()
                .ForMember(d => d.Roles, map => map.Ignore())
                .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

            CreateMap<ApplicationUser, UserEditVM>()
                .ForMember(d => d.Roles, map => map.Ignore());
            CreateMap<UserEditVM, ApplicationUser>()
                .ForMember(d => d.Roles, map => map.Ignore())
                .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

            CreateMap<ApplicationUser, UserPatchVM>()
                .ReverseMap();

            CreateMap<ApplicationRole, RoleVM>()
                .ForMember(d => d.Permissions, map => map.MapFrom(s => s.Claims))
                .ForMember(d => d.UsersCount, map => map.MapFrom(s => s.Users != null ? s.Users.Count : 0))
                .ReverseMap();
            CreateMap<RoleVM, ApplicationRole>()
                .ForMember(d => d.Id, map => map.Condition(src => src.Id != null));

            CreateMap<IdentityRoleClaim<string>, ClaimVM>()
                .ForMember(d => d.Type, map => map.MapFrom(s => s.ClaimType))
                .ForMember(d => d.Value, map => map.MapFrom(s => s.ClaimValue))
                .ReverseMap();

            CreateMap<ApplicationPermission, PermissionVM>()
                .ReverseMap();

            CreateMap<IdentityRoleClaim<string>, PermissionVM>()
                .ConvertUsing(s => ((PermissionVM)ApplicationPermissions.GetPermissionByValue(s.ClaimValue))!);

            CreateMap<Customer, CustomerVM>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => ParseGender(src.Gender)));

            CreateMap<Product, ProductVM>()
                .ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => src.DiscountPercent));
            CreateMap<ProductVM, Product>()
                .ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => src.DiscountPercent));

            CreateMap<Order, OrderVM>()
                .ReverseMap();
        }

        private static Proyecto_Final_Progra_6.Core.Models.Gender ParseGender(string? gender)
        {
            if (Enum.TryParse<Proyecto_Final_Progra_6.Core.Models.Gender>(gender, out var result))
                return result;
            return Proyecto_Final_Progra_6.Core.Models.Gender.None;
        }
    }
}
