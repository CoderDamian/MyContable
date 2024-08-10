using AutoMapper;
using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-ST-002	Listar los secuenciales de tipo de asiento	
    /// </summary>
    internal class SecuencialesListHandler : IRequestHandler<SecuencialList, IEnumerable<ListSecuencialDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SecuencialesListHandler()
        {
            
        }

        public SecuencialesListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(MyMessages.uow_not_be_null);
            this._mapper = mapper ?? throw new ArgumentNullException(MyMessages.mapper_not_be_null);
        }

        public async Task<IEnumerable<ListSecuencialDTO>> Handle(SecuencialList request, CancellationToken cancellationToken)
        {
            var secuenciales =  await this._unitOfWork.SecuencialRepository.Gell_All_Async().ConfigureAwait(false);

            //var secuencialesDTO = this._mapper.Map<IEnumerable<ListSecuencialDTO>>(secuenciales);

            return (secuenciales);
        }
    }
}