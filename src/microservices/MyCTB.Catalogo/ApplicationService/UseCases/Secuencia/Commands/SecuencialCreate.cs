using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record class SecuencialCreate(AddSecuencialDTO SecuencialDTO) : IRequest { }
}