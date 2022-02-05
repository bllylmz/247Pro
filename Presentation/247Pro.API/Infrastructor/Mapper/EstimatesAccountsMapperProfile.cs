using AutoMapper;
using _247Pro.Common.DTOs.EstimatesAccounts;
using _247Pro.Common.Extensions;
using _247Pro.Model.Entities;

namespace _247Pro.API.Infrastructor.Mapper
{
    public class EstimatesAccountsMapperProfile : Profile
    {
        public EstimatesAccountsMapperProfile()
        {
            CreateMap<EstimatesAccounts, EstimatesAccountsRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EstimatesAccounts, EstimatesAccountsResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
