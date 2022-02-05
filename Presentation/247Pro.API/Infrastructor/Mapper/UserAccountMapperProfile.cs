using _247Pro.Common.DTOs.UserAccount;
using _247Pro.Common.Extensions;
using _247Pro.Model.Entities;
using AutoMapper;

namespace _247Pro.API.Infrastructor.Mapper
{
    public class UserAccountMapperProfile : Profile
    {
        public UserAccountMapperProfile()
        {
            CreateMap<UserAccount, UserAccountRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<UserAccount, UserAccountResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
