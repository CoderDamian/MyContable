using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record class TipoAsientoDelete(int TipoAsientoId, DeleteTipoAsientoDTO TipoAsientoDTO) : IRequest { }
}
