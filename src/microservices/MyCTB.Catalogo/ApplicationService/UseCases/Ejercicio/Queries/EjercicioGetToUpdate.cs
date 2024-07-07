using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public readonly record struct EjercicioGetToUpdate(int Id) : IRequest<UpdateEjercicioDTO>;
}
