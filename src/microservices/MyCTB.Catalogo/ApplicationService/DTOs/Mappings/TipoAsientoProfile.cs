using AutoMapper;
using MyDTO.MyContabilidad;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.ApplicationService.Mappings
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
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Created_By))
                .ReverseMap();

            CreateMap<TipoAsiento, ListTiposAsientoDTO>()
                .ReverseMap();

            CreateMap<TipoAsiento, UpdateTipoAsientoDTO>()
                .ForMember(dest => dest.User_Name, opt => opt.MapFrom(src => src.Updated_By))
                .ForMember(dest => dest.Last_Updated_Date, opt => opt.MapFrom(src => src.Updated_Date))
                .ReverseMap();
        }
    }
}