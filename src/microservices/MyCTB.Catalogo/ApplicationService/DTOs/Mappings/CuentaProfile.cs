using AutoMapper;
using MyDTO.MyContabilidad;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.ApplicationService.Mappings
{
    public class CuentaProfile : Profile
    {
        public CuentaProfile()
        {
            CreateMap<Cuenta, PlanCuentasDTO>()
                .ForMember(dest => dest.CodigoContable, opt => opt.MapFrom(src => src.Codigo_Contable.Value))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.NombreCategoria, opt => opt.MapFrom(src => src.Categoria.Nombre))
                .ReverseMap();
        }
    }
}