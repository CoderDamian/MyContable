using AutoMapper;
using MediatR;
using MyCTB.Catalogo.BusinessDomain;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// USe Case: CU-TA-001	Crear un tipo de asiento contable	
    /// </summary>

    internal class TipoAsientoCreateHandler : IRequestHandler<TipoAsientoCreate>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoAsientoCreateHandler()
        {
            
        }

        internal TipoAsientoCreateHandler(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            this._unitOfWork = UnitOfWork ?? throw new ArgumentNullException(nameof(UnitOfWork));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task Handle(TipoAsientoCreate request, CancellationToken cancellationToken)
        {
            var tipoAsiento = this._mapper.Map<TipoAsiento>(request.TipoAsientoDTO);

            // Business rule: el nombre del Usuario que crea el registro no puede ser nulo o vacio
            if (String.IsNullOrEmpty(tipoAsiento.CreatedBy))
                throw new ApplicationException(MyMessages.user_can_not_be_empty_or_null);

            // Business rule: un tipo nuevo siempre debe ser activa
            tipoAsiento.Set_EsActiva(true);

            await this._unitOfWork.TipoAsientoRepository.Add_Async(tipoAsientoContable: tipoAsiento).ConfigureAwait(false);

            await this._unitOfWork.Save_Async().ConfigureAwait(false);
        }
    }
}
