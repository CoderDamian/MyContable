using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record CentroCostoUpdate(int Id, UpdateCentroCostoDTO CentroCostoDTO) : IRequest { }
}
