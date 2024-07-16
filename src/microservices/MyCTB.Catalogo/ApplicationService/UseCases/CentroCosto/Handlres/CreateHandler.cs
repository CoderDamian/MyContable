using MediatR;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-CC-001	Crear un centro de costo	
    /// </summary>
    internal class CentroCostoCreateHandler : IRequestHandler<CentroCostoCreate>
    {
        private readonly IUnitOfWork _unitOfWork;

        internal CentroCostoCreateHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <summary>
        /// Add a new CENTRO DE COSTO record
        /// </summary>
        /// <remarks>
        /// The logic business application is found in the procedure: CENTRO_COSTO_PKG.ADD_NEW
        /// </remarks>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task Handle(CentroCostoCreate request, CancellationToken cancellationToken)
        {
            // Business rule: The new record must have an user name
            if (String.IsNullOrEmpty(request.CentroCostoDTO.UserName))
            {
                throw new ApplicationException(MyMessages.user_can_not_be_empty_or_null);
            }
            else
            {
                await _unitOfWork.CentroCostoRepository
                    .Add_Async(centroCostoPadreId: request.CentroCostoDTO.PadreId,
                        nombre: request.CentroCostoDTO.Nombre,
                        userName: request.CentroCostoDTO.UserName)
                    .ConfigureAwait(false);

                //Not necessary call to Save_Async() since the repository use ExecuteSqlRawAsync
                //await _unitOfWork.Save_Async().ConfigureAwait(false);
            }
        }
    }
}
