using AutoMapper;
using NgWalks.Api.Models.Domain;
using NgWalks.Api.Models.DTO;

namespace NgWalks.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Region,RegionDto>().ForMember(x=>x.Name, opt =>opt.MapFrom(x=>x.Code)).ReverseMap();
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDtos, Region>().ReverseMap();
            CreateMap<UpdateRegionRequest, Region>().ReverseMap();
            CreateMap<Walk, AddWalkRequestDto>().ReverseMap();
            CreateMap<WalkDto, Walk>().ReverseMap();
            CreateMap<DifficultyDto, Difficulty>().ReverseMap();
            CreateMap<UpdateWalkDto, Walk>().ReverseMap();

        }
    }
}
