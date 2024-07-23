using AutoMapper;
using MediatR;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public record AddCuentaRequest(AddDTO Cuenta) : IRequest { };

    internal class CuentaAddHandler : IRequestHandler<AddCuentaRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CuentaAddHandler()
        {
            
        }

        internal CuentaAddHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(MyMessages.uow_not_be_null);
            this._mapper = mapper;
        }

        // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
        public async Task Handle(AddCuentaRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.CuentaRepository
                .Add_Cuenta_Async(request.Cuenta.CodigoContablePadre, request.Cuenta.Nombre, request.Cuenta.CreatedBy)
                .ConfigureAwait(false);

            await _unitOfWork.Save_Async().ConfigureAwait(false);
        }
    }
}