using AutoMapper;
using MarketDataAPI.Data.Entities;
using MarketDataAPI.Dtos;

namespace MarketDataAPI.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Instrumenty, InstrumentDto>()
            .ForMember(dest => dest.Mappings, opt => opt.MapFrom(src => src.Mappings));
        CreateMap<Mappings, MappingsDto>()
            .ForMember(dest => dest.ActiveTick, opt => opt.MapFrom(src => src.ActiveTick))
            .ForMember(dest => dest.Simulation, opt => opt.MapFrom(src => src.Simulation))
            .ForMember(dest => dest.Oanda, opt => opt.MapFrom(src => src.Oanda));
        CreateMap<MappingDetails, MappingDetailsDto>();
    }
}
