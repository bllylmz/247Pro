using _247Pro.Common.DTOs.RolePermission;
using _247Pro.Common.Extensions;
using _247Pro.Model.Entities;
using AutoMapper;

namespace _247Pro.API.Infrastructor.Mapper
{
    public class RolePermissionMapperProfile : Profile
    {
        public RolePermissionMapperProfile()
        {
            CreateMap<RolePermission, RolePermissionRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<RolePermission, RolePermissionResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
