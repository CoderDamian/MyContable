using AutoMapper;
using MyCTB.Catalogo.BusinessDomain;

namespace MyDTO.MyContabilidad
{
    public class PeriodoProfile : Profile
    {
        public PeriodoProfile()
        {
            // By default, AutoMapper only recognizes public members.
            // To instruct AutoMapper to recognize internal members, override the filters ShouldMapProperty
            // https://docs.automapper.org/en/stable/Configuration.html
            ShouldMapProperty = p => p.GetMethod == null ? throw new NullReferenceException() : p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

            CreateMap<Periodo, ListPeriodoDTO>()
                .ReverseMap();
        }
    }
}