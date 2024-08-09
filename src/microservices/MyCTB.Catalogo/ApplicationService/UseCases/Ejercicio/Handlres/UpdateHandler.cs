using MediatR;
using System.Data;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-EF-002 ACTUALIZAR UN EJERCICIO CONTABLE
    /// </summary>
    internal class EjercicioUpdateHandler : IRequestHandler<EjercicioUpdate>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EjercicioUpdateHandler()
        {
            
        }

        internal EjercicioUpdateHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        async Task IRequestHandler<EjercicioUpdate>.Handle(EjercicioUpdate request, CancellationToken cancellationToken)
        {
            var rowsAffected = await this._unitOfWork.EjercicioRepository.Update_Async(
                id: request.EjercicioDTO.Id,
                nombre: request.EjercicioDTO.Nombre,
                user_name: request.EjercicioDTO.UserName,
                lastUpdatedDate: request.EjercicioDTO.LastUpdatedDate)
                .ConfigureAwait(false);

            // Concurrency check is verified by code
            if (rowsAffected != 1)
            {
                throw new DBConcurrencyException(MyMessages.update_does_not_occurred);
            }
        }
    }
}