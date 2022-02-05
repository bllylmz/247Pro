using _247Pro.Common.DTOs.AccountRolePermission;
using _247Pro.Common.Extensions;
using _247Pro.Model.Entities;
using AutoMapper;

namespace _247Pro.API.Infrastructor.Mapper
{
    public class AccountRolePermissionMapperProfile : Profile
    {
        public AccountRolePermissionMapperProfile()
        {
            CreateMap<AccountRolePermission, AccountRolePermissionRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<AccountRolePermission, AccountRolePermissionResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
