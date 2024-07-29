using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyDTO.MyContabilidad;
using MyCTB.Catalogo.ApplicationService;

namespace MyCTB.Catalogo.WebServices
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SecuencialController : ControllerBase
    {
        private readonly ILogger<SecuencialController> _logger;
        private readonly IMediator _mediator;

        public SecuencialController(ILogger<SecuencialController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await this._mediator.Send(new SecuencialList()).ConfigureAwait(false);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorId = 1;

                _logger.LogError(errorId, "Error ocurred in API {message}", ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSecuencialDTO secuencialDTO)
        {
            try
            {
                await this._mediator.Send(new SecuencialCreate(secuencialDTO)).ConfigureAwait(false);

                return Ok();
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