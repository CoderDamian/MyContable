using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record class SecuencialList : IRequest<IEnumerable<ListSecuencialDTO>>;
}