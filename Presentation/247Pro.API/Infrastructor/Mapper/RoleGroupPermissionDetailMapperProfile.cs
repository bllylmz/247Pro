using _247Pro.Common.DTOs.RoleGroupPermissionDetail;
using _247Pro.Common.Extensions;
using _247Pro.Model.Entities;
using AutoMapper;

namespace _247Pro.API.Infrastructor.Mapper
{
    public class RoleGroupPermissionDetailMapperProfile : Profile
    {
        public RoleGroupPermissionDetailMapperProfile()
        {
            CreateMap<RoleGroupPermissionDetail, RoleGroupPermissionDetailRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<RoleGroupPermissionDetail, RoleGroupPermissionDetailResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
