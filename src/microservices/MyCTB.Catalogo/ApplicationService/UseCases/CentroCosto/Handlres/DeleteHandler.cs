using MediatR;

namespace MyCTB.Catalogo.ApplicationService
{

    /// <summary>
    /// Use Case: CU-CC-003	Eliminar un centro de costo	
    /// </summary>
    internal class CentroCostoDeleteHandler : IRequestHandler<CentroCostoDelete>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CentroCostoDeleteHandler()
        {
            
        }

        internal CentroCostoDeleteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Soft delete an CENTRO DE COSTO record
        /// </summary>
        /// <remarks>
        /// The logic business application is found in the procedure: CENTRO_COSTO_PKG.DELETE_BY_ID
        /// </remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task Handle(CentroCostoDelete request, CancellationToken cancellationToken)
        {
            await this._unitOfWork.CentroCostoRepository
                .Delete_Async(id: request.CentroCostoId, updatedBy: request.CentroCostoDTO.UserName, concurrency_token: request.CentroCostoDTO.LastUpdatedDate)
                .ConfigureAwait(false);

            //Not necessary call to Save_Async() since the repository use ExecuteSqlRawAsync
            //await _unitOfWork.Save_Async().ConfigureAwait(false);
        }
    }
}