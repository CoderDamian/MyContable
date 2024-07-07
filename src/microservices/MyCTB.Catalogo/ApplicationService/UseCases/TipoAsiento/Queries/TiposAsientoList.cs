using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record class TiposAsientoList(int skip, int take) : IRequest<IEnumerable<ListTiposAsientoDTO>>;

}