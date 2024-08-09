using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// USe Case: CU-CC-004	Listar los centros de costo	
    /// </summary>
    internal class CentrosCostosListHandler : IRequestHandler<CentroCostoList, IEnumerable<ListCentrosCostosDTO>>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CentrosCostosListHandler()
        {

        }

        public CentrosCostosListHandler(ILogger<CentrosCostosListHandler> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task<IEnumerable<ListCentrosCostosDTO>> Handle(CentroCostoList request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("inside CentrosCostosListHandler ...");

            var centrosCostos = await this._unitOfWork.CentroCostoRepository
                .Get_All_Async()
                .ConfigureAwait(false);

            var centrosoCostosDTO = _mapper.Map<IEnumerable<ListCentrosCostosDTO>>(centrosCostos);

            return centrosoCostosDTO;
        }
    }
}
