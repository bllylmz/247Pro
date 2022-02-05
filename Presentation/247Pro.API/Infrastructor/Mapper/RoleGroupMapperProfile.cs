using _247Pro.Common.DTOs.RoleGroup;
using _247Pro.Common.Extensions;
using _247Pro.Model.Entities;
using AutoMapper;

namespace _247Pro.API.Infrastructor.Mapper
{
    public class RoleGroupMapperProfile : Profile
    {
        public RoleGroupMapperProfile()
        {
            CreateMap<RoleGroup, RoleGroupRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<RoleGroup, RoleGroupResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
