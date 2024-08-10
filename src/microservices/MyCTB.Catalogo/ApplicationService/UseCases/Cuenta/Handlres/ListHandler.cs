using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    internal class PlanCuentasListHandler : IRequestHandler<CuentaList, IEnumerable<PlanCuentasDTO>>
    {
        private readonly ILogger<PlanCuentasListHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlanCuentasListHandler()
        {
            
        }

        public PlanCuentasListHandler(ILogger<PlanCuentasListHandler> logger,  IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(MyMessages.uow_not_be_null);
            _mapper = mapper ?? throw new ArgumentNullException(MyMessages.mapper_not_be_null);
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task<IEnumerable<PlanCuentasDTO>> Handle(CuentaList request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("consultando base de datos !!!");

            var cuentasContables = await _unitOfWork.CuentaRepository
                .Get_Plan_Cuentas_Async(
                    offset: request.Offset,
                    fetch: request.Fetch)
                .ConfigureAwait(false);

            _logger.LogInformation("transformando a DTOs el resultado ...");

            var planDeCuentaDTO = _mapper.Map<IEnumerable<PlanCuentasDTO>>(cuentasContables);

            return planDeCuentaDTO;
        }
    }
}
