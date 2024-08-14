using MediatR;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-PC-001 Crear un periodo contable
    /// </summary>
    internal class PeriodoCreateHandler : IRequestHandler<PeriodoCreate>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeriodoCreateHandler()
        {
            
        }

        /// <summary>
        /// la visibilidad debe ser public
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PeriodoCreateHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task Handle(PeriodoCreate request, CancellationToken cancellationToken)
        {
            await this._unitOfWork.PeriodoRepository
                .Add_Async(nombre: request.PeriodoDTO.Nombre, fechaInicial: request.PeriodoDTO.FechaInicial, numeroPeriodos: request.PeriodoDTO.NumeroPeridos, longitud: request.PeriodoDTO.Longitud, userName: request.PeriodoDTO.UserName)
                .ConfigureAwait(false);
        }
    }
}