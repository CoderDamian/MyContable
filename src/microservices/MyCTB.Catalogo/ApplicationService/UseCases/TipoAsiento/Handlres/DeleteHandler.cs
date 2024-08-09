using MediatR;
using System.Data;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-TA-003	Eliminar un tipo de asiento contable	
    /// </summary>
    internal class TipoAsientoDeleteHandler : IRequestHandler<TipoAsientoDelete>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoAsientoDeleteHandler()
        {
            
        }

        internal TipoAsientoDeleteHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The logic business application is found in the procedure: TIPO_ASIENTO_PKG.DELETE_BY_ID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(TipoAsientoDelete request, CancellationToken cancellationToken)
        {
            int rows_affected = await this._unitOfWork.TipoAsientoRepository
                .Delete_Async(
                    id: request.TipoAsientoId,
                    updatedBy: request.TipoAsientoDTO.UserName,
                    concurrencyToken: request.TipoAsientoDTO.LastUpdatedDate)
                .ConfigureAwait(false);

            if (rows_affected != 1)
            {
                throw new DBConcurrencyException(MyMessages.update_does_not_occurred);
            }

            //Not necessary call to Save_Async() since the repository use ExecuteSqlRawAsync
            //await _unitOfWork.Save_Async().ConfigureAwait(false);
        }
    }
}
