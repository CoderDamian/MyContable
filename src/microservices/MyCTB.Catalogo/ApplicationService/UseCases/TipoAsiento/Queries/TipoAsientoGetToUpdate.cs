using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record class TipoAsientoGetToUpdate(int Tipo_Asiento_Id) : IRequest<UpdateTipoAsientoDTO>
    {
    }
}