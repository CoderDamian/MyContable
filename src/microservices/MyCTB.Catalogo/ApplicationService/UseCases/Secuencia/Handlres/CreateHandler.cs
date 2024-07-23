using AutoMapper;
using MediatR;
using MyCTB.Catalogo.BusinessDomain;
namespace MyCTB.Catalogo.ApplicationService
{
    /// <summary>
    /// Use Case: CU-ST-001	Agregar un secuencial de tipo de asiento	
    /// </summary>
    internal class SecuencialCreateHandler : IRequestHandler<SecuencialCreate>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SecuencialCreateHandler()
        {
            
        }

        internal SecuencialCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        // el metodo debe ser de tipo PUBLIC porque asi lo exige MediatR
        public async Task Handle(SecuencialCreate request, CancellationToken cancellationToken)
        {
            var secuencial = this._mapper.Map<Secuencial>(request.SecuencialDTO);

            await this._unitOfWork.SecuencialRepository
                .Add_Async(secuencial)
                .ConfigureAwait(false);

            await this._unitOfWork.Save_Async().ConfigureAwait(false);
        }
    }
}

