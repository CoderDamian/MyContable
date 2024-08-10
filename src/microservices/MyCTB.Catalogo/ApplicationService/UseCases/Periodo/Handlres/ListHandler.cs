using AutoMapper;
using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-PC-003	Listar los periodos contables
    /// </summary>
    internal class PeriodosListHandler : IRequestHandler<PeriodoList, IEnumerable<ListPeriodoDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PeriodosListHandler()
        {
            
        }

        public PeriodosListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ListPeriodoDTO>> Handle(PeriodoList request, CancellationToken cancellationToken)
        {
            var periodos = await this._unitOfWork.PeriodoRepository
                .Get_All_Async()
                .ConfigureAwait(false);

            var periodosDTO = this._mapper.Map<IEnumerable<ListPeriodoDTO>>(periodos);

            return (periodosDTO);
        }
    }
}