using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record CentroCostoDelete(int CentroCostoId, DeleteCentroCostoDTO CentroCostoDTO) : IRequest { }
}
