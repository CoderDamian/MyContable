using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCTB.Catalogo.ApplicationService;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.WebServices
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CentroCostoController : ControllerBase
    {
        private readonly ILogger<CentroCostoController> _logger;
        private readonly IMediator _mediator;

        public CentroCostoController(ILogger<CentroCostoController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCentroCostoDTO centroCostoDTO)
        {
            try
            {
                await this._mediator.Send(new CentroCostoCreate(centroCostoDTO)).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();

                //return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, [FromBody] DeleteCentroCostoDTO centroCostoDTO)
        {
            try
            {
                await this._mediator.Send(new CentroCostoDelete(id, centroCostoDTO)).ConfigureAwait(false);

                return NoContent();
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get_All()
        {
            try
            {
                _logger.LogInformation("processing CetroCostoController ...");

                var centrosCostos = await this._mediator.Send(new CentroCostoList()).ConfigureAwait(false);

                return Ok(centrosCostos);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                _logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                ModelState.AddModelError(nameof(ex), ex.Message);

                return ValidationProblem();

                //return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get_By_Id(int id)
        {
            try
            {
                UpdateCentroCostoDTO centroCostoDTO = await this._mediator.Send(new CentroCostoGetToUpdate(id)).ConfigureAwait(false);

                return Ok(centroCostoDTO);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCentroCostoDTO centroCostoDTO)
        {
            try
            {
                await this._mediator.Send(new CentroCostoUpdate(id, centroCostoDTO)).ConfigureAwait(false);

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();
            }
        }
    }
}