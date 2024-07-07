using AutoMapper;
using MyDTO.MyContabilidad;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.ApplicationService.Mappings
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

            CreateMap<CentroCosto, UpdateCentroCostoDTO>()
                .ForMember(dest => dest.User_Name, opt => opt.MapFrom(src => src.Updated_By))
                .ForMember(dest => dest.Last_Updated_Date, opt => opt.MapFrom(src => src.Updated_Date))
                .ReverseMap();
        }
    }
}
