using AutoMapper;
using MediatR;
using MyCTB.Catalogo.BusinessDomain;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-TA-002	Actualizar un tipo de asiento contable	
    /// </summary>
    internal class TipoAsientoUpdateHandler : IRequestHandler<TipoAsientoUpdate>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        internal TipoAsientoUpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._mapper = mapper;
        }

        async Task IRequestHandler<TipoAsientoUpdate>.Handle(TipoAsientoUpdate request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.TipoAsientoDTO.User_Name))
                throw new ApplicationException(MyMessages.user_can_not_be_empty_or_null);

            TipoAsiento tipoAsiento = this._mapper.Map<TipoAsiento>(request.TipoAsientoDTO);

            this._unitOfWork.TipoAsientoRepository.Update(tipoAsiento);

            // EF Core check ConcurrencyCheck
            await this._unitOfWork.Save_Async().ConfigureAwait(false);
        }
    }
}
