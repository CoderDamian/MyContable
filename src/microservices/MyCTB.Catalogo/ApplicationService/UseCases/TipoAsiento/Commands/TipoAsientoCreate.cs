using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record TipoAsientoCreate(AddTipoAsientoDTO TipoAsientoDTO) : IRequest { }
}
