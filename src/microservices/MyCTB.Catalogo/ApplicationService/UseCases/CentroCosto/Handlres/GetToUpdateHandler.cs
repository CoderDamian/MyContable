using AutoMapper;
using MediatR;
using MyCTB.Catalogo.BusinessDomain;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    internal class CentroCostoGetToUpdateHandler : IRequestHandler<CentroCostoGetToUpdate, UpdateCentroCostoDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        internal CentroCostoGetToUpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task<UpdateCentroCostoDTO> Handle(CentroCostoGetToUpdate request, CancellationToken cancellationToken)
        {
            CentroCosto? centroCosto = await this._unitOfWork.CentroCostoRepository
                .Get_By_Id_Async(request.Id)
                .ConfigureAwait(false);

            UpdateCentroCostoDTO centroCostoDTO = this._mapper.Map<UpdateCentroCostoDTO>(centroCosto);

            return centroCostoDTO;
        }
    }
}
