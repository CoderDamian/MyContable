using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public readonly record struct EjercicioList : IRequest<IEnumerable<ListEjercicioDTO>>;
}
