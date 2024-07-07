using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record TipoAsientoUpdate(int TipoAsientoId, UpdateTipoAsientoDTO TipoAsientoDTO) : IRequest { }
}
