using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record CentroCostoCreate(AddCentroCostoDTO CentroCostoDTO) : IRequest { };

}
