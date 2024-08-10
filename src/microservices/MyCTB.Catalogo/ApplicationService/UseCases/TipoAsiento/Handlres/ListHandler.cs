using AutoMapper;
using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-TA-004	Listar los tipos de asiento contable	
    /// </summary>
    internal class TiposAsientosListHandler : IRequestHandler<TiposAsientoList, IEnumerable<ListTiposAsientoDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TiposAsientosListHandler()
        {
            
        }

        public TiposAsientosListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ListTiposAsientoDTO>> Handle(TiposAsientoList request, CancellationToken cancellationToken)
        {
            var tiposAsientos = await this._unitOfWork.TipoAsientoRepository
                .Get_All_Async(
                    skip: request.skip, 
                    take: request.take)
                .ConfigureAwait(false);

            var tiposAsientoDTOs = this._mapper.Map<IEnumerable<ListTiposAsientoDTO>>(tiposAsientos);

            return tiposAsientoDTOs;
        }
    }
}