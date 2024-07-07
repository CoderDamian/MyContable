using AutoMapper;
using MyDTO.MyContabilidad;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.ApplicationService.Mappings
{
    public class SecuencialProfile : Profile
    {
        public SecuencialProfile()
        {
            // By default, AutoMapper only recognizes public members.
            // To instruct AutoMapper to recognize internal members, override the filters ShouldMapProperty
            // https://docs.automapper.org/en/stable/Configuration.html
            ShouldMapProperty = p => p.GetMethod == null ? throw new NullReferenceException() : p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

            CreateMap<Secuencial, AddSecuencialDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Created_By))
                .ReverseMap();

            //CreateMap<Secuencial, ListSecuencialDTO>()
            //    .ForMember(dest => dest.NombrePeriodo, opt => opt.MapFrom(src => src.Periodo.Nombre))
            //    .ForMember(dest => dest.TipoAsiento, opt => opt.MapFrom(src => src.TipoAsiento.Nombre))
            //    .ReverseMap();
        }
    }
}