using AutoMapper;
using MediatR;
using MyCTB.Catalogo.BusinessDomain;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    internal class TipoAsientoGetToUpdateHandler : IRequestHandler<TipoAsientoGetToUpdate, UpdateTipoAsientoDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoAsientoGetToUpdateHandler()
        {
            
        }

        internal TipoAsientoGetToUpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task<UpdateTipoAsientoDTO> Handle(TipoAsientoGetToUpdate request, CancellationToken cancellationToken)
        {
            TipoAsiento? tipoAsiento = await this._unitOfWork.TipoAsientoRepository
                .Get_By_Id_Async(request.Tipo_Asiento_Id)
                .ConfigureAwait(false);

            if (tipoAsiento == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                var tipoAsientoDTO = this._mapper.Map<UpdateTipoAsientoDTO>(tipoAsiento);

                return tipoAsientoDTO;
            }
        }
    }
}