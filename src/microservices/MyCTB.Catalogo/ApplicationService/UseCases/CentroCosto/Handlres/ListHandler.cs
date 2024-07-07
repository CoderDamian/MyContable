using AutoMapper;
using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// USe Case: CU-CC-004	Listar los centros de costo	
    /// </summary>
    internal class CentrosCostosListHandler : IRequestHandler<CentroCostoList, IEnumerable<ListCentrosCostosDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        internal CentrosCostosListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task<IEnumerable<ListCentrosCostosDTO>> Handle(CentroCostoList request, CancellationToken cancellationToken)
        {
            var centrosCostosDTOs = await this._unitOfWork.CentroCostoRepository
                .Get_All_Async()
                .ConfigureAwait(false);

            return centrosCostosDTOs;
        }
    }
}
