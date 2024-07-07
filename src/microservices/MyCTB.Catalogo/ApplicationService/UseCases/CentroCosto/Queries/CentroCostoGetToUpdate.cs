using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record class CentroCostoGetToUpdate(int Id) : IRequest<UpdateCentroCostoDTO>;
}