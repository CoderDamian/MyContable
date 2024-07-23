using AutoMapper;
using MediatR;
using MyCTB.Catalogo.BusinessDomain;

namespace MyCTB.Catalogo.ApplicationService;


/// <summary>
/// USe Case: CU-CC-002	Actualizar un centro de costo	
/// </summary>
internal class CentroCostoUpdateHandler : IRequestHandler<CentroCostoUpdate>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    internal CentroCostoUpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public CentroCostoUpdateHandler()
    {
        
    }

    /// <summary>
    /// Caso de Uso: CU-CC-002
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// // el metodo debe ser del tipo PUBLIC porque asi lo exige MediatR
    public async Task Handle(CentroCostoUpdate request, CancellationToken cancellationToken)
    {
        var centroCosto = this._mapper.Map<CentroCosto>(request.CentroCostoDTO);

        this._unitOfWork.CentroCostoRepository
            .Update(centroCosto: centroCosto);

        // EF Core check ConcurrencyCheck
        await this._unitOfWork.Save_Async().ConfigureAwait(false);
    }
}