using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record class PeriodoCreate(AddPeriodoDTO PeriodoDTO) : IRequest { }

}