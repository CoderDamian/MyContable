using AutoMapper;
using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-EF-003 LISTAR LOS EJERCICIOS CONTABLES
    /// </summary>
    internal class EjerciciosListHandler : IRequestHandler<EjercicioList, IEnumerable<ListEjercicioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //public EjerciciosListHandler()
        //{
            
        //}

        public EjerciciosListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task<IEnumerable<ListEjercicioDTO>> Handle(EjercicioList request, CancellationToken cancellationToken)
        {
            var ejercicios = await this._unitOfWork.EjercicioRepository.Get_All_Async().ConfigureAwait(false);

            var ejerciciosDTO = _mapper.Map<IEnumerable<ListEjercicioDTO>>(ejercicios);

            return ejerciciosDTO;
        }
    }
}
