using AutoMapper;
using MyCTB.Catalogo.BusinessDomain;

namespace MyDTO.MyContabilidad
{
    public class TipoAsientoProfile : Profile
    {
        public TipoAsientoProfile()
        {
            // By default, AutoMapper only recognizes public members.
            // To instruct AutoMapper to recognize internal members, override the filters ShouldMapProperty
            // https://docs.automapper.org/en/stable/Configuration.html
            ShouldMapProperty = p => p.GetMethod == null ? throw new NullReferenceException() : p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

            CreateMap<TipoAsiento, AddTipoAsientoDTO>()
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.CreatedBy))
                .ReverseMap();

            CreateMap<TipoAsiento, ListTiposAsientoDTO>()
                .ReverseMap();

            CreateMap<TipoAsiento, UpdateTipoAsientoDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.LastUpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                .ReverseMap();
        }
    }
}