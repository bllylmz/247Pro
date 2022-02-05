using _247Pro.Common.DTOs.Estimate;
using _247Pro.Common.Extensions;
using _247Pro.Model.Entities;
using AutoMapper;

namespace _247Pro.API.Infrastructor.Mapper
{
    public class EstimateMapperProfile : Profile
    {
        public EstimateMapperProfile()
        {
            CreateMap<Estimate, EstimateRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Estimate, EstimateResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
