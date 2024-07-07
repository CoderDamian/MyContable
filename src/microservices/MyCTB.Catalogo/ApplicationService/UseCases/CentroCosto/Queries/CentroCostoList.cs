using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record struct CentroCostoList : IRequest<IEnumerable<ListCentrosCostosDTO>>;
}
