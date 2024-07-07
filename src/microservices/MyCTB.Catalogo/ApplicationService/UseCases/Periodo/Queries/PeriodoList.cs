using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record class PeriodoList() : IRequest<IEnumerable<ListPeriodoDTO>>;
}