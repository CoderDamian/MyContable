using AutoMapper;
using MyCTB.Catalogo.BusinessDomain;

namespace MyDTO.MyContabilidad
{
    public class CuentaProfile : Profile
    {
        public CuentaProfile()
        {
            CreateMap<Cuenta, PlanCuentasDTO>()
                .ForMember(dest => dest.CodigoContable, opt => opt.MapFrom(src => src.CodigoContable!.Value))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.NombreCategoria, opt => opt.MapFrom(src => src.Categoria!.Nombre))
                .ReverseMap();
        }
    }
}