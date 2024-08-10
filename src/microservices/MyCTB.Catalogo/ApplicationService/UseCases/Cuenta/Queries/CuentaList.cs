using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record struct CuentaList(int Offset, int Fetch) : IRequest<IEnumerable<PlanCuentasDTO>>;
}
