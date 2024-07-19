using AutoMapper;
using MyCTB.Catalogo.BusinessDomain;
using MyDTO.MyContabilidad;

namespace MyDTO.MyContabilidad
{
    public class EjercicioProfile : Profile
    {
        public EjercicioProfile()
        {
            // By default, AutoMapper only recognizes public members.
            // To instruct AutoMapper to recognize internal members, override the filters ShouldMapProperty
            // https://docs.automapper.org/en/stable/Configuration.html

            ShouldMapProperty = p => p.GetMethod == null ? throw new NullReferenceException() : p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

            CreateMap<Ejercicio, ListEjercicioDTO>()
                .ReverseMap();

            CreateMap<Ejercicio, UpdateEjercicioDTO>()
                .ForMember(dest => dest.User_Name, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.Last_Updated_Date, opt => opt.MapFrom(src => src.UpdatedDate))
                .ReverseMap();
        }
    }
}
