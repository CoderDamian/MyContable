using AutoMapper;
using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: EF-002 ACTUALIZAR UN EJERCICIO CONTABLE
    /// </summary>
    internal class EjercicioGetToUpdateHandler : IRequestHandler<EjercicioGetToUpdate, UpdateEjercicioDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        internal EjercicioGetToUpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task<UpdateEjercicioDTO> Handle(EjercicioGetToUpdate request, CancellationToken cancellationToken)
        {
            var ejercicio = await this._unitOfWork.EjercicioRepository.Get_By_Id_Async(request.Id).ConfigureAwait(false);

            if (ejercicio is null)
            {
                throw new NullReferenceException(nameof(ejercicio));
            }
            else
            {
                var ejercicioDTO = this._mapper.Map<UpdateEjercicioDTO>(ejercicio);

                return ejercicioDTO;
            }
        }
    }
}
