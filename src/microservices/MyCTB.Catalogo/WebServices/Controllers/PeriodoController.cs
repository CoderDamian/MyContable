using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCTB.Catalogo.ApplicationService;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.WebServices
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PeriodoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PeriodoController> _logger;

        public PeriodoController(ILogger<PeriodoController> logger, IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add_Periodo([FromBody] AddPeriodoDTO periodoDTO)
        {
            try
            {
                await this._mediator.Send(new PeriodoCreate(periodoDTO)).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get_Periodos()
        {
            try
            {
                var periodoDTOs = await this._mediator.Send(new PeriodoList()).ConfigureAwait(false);

                return Ok(periodoDTOs);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}