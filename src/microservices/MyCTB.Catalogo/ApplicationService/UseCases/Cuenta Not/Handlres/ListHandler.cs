using AutoMapper;
using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    internal class PlanCuentasListHandler : IRequestHandler<CuentaList, IEnumerable<PlanCuentasDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlanCuentasListHandler()
        {
            
        }

        internal PlanCuentasListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(MyMessages.uow_not_be_null);
            this._mapper = mapper ?? throw new ArgumentNullException(MyMessages.mapper_not_be_null);
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task<IEnumerable<PlanCuentasDTO>> Handle(CuentaList request, CancellationToken cancellationToken)
        {
            var cuentasContables = await _unitOfWork.CuentaRepository
                .Get_PlanCuentas_Async(
                    offset: request.Offset,
                    fetch: request.Fetch)
                .ConfigureAwait(false);

            var planDeCuentaDTO = _mapper.Map<IEnumerable<PlanCuentasDTO>>(cuentasContables);

            return planDeCuentaDTO;
        }
    }
}
