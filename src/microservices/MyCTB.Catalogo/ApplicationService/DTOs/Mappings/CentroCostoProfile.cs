using AutoMapper;
using MyCTB.Catalogo.BusinessDomain;

namespace MyDTO.MyContabilidad
{
    public class CentroCostoProfile : Profile
    {
        public CentroCostoProfile()
        {
            // By default, AutoMapper only recognizes public members.
            // To instruct AutoMapper to recognize internal members, override the filters ShouldMapProperty
            // https://docs.automapper.org/en/stable/Configuration.html

            ShouldMapProperty = p => p.GetMethod == null ? throw new NullReferenceException() : p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

            CreateMap<CentroCosto, AddCentroCostoDTO>()
                .ForMember(dest => dest.UserName, opt => opt.Ignore())
                .ReverseMap(); 

            CreateMap<CentroCosto, ListCentrosCostosDTO>()
                .ReverseMap();

            CreateMap<CentroCosto, UpdateCentroCostoDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.LastUpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                .ReverseMap();
        }
    }
}
