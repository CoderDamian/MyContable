using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyDTO.MyContabilidad;
using MyCTB.Catalogo.ApplicationService;
using Microsoft.EntityFrameworkCore;

namespace MyCTB.Catalogo.WebServices
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TipoAsientoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public TipoAsientoController(ILogger<TipoAsientoController> logger, IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get_By_ID(int id)
        {
            try
            {
                UpdateTipoAsientoDTO tipoAsiento = await this._mediator.Send(new TipoAsientoGetToUpdate(id)).ConfigureAwait(false);

                return Ok(tipoAsiento);
            }
            catch (Exception ex)
            {
                var errorId = new Guid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();
            }
        }

        [HttpGet]
        public async Task<IActionResult> List_All([FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                var tiposAsientoDTOs = await this._mediator.Send(new TiposAsientoList(skip: skip, take: take)).ConfigureAwait(false);

                return Ok(tiposAsientoDTOs);
            }
            catch (Exception ex)
            {
                var errorId = new Guid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] DeleteTipoAsientoDTO tipoAsientoDTO)
        {
            try
            {
                await this._mediator.Send(new TipoAsientoDelete(id, tipoAsientoDTO)).ConfigureAwait(false);

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var errorId = new Guid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();
            }
            catch (Exception ex)
            {
                var errorId = new Guid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTipoAsientoDTO tipoAsientoDTO)
        {
            try
            {
                await this._mediator.Send(new TipoAsientoCreate(tipoAsientoDTO)).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception ex)
            {
                var errorId = new Guid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTipoAsientoDTO tipoAsientoDTO)
        {
            try
            {
                await this._mediator.Send(new TipoAsientoUpdate(id, tipoAsientoDTO)).ConfigureAwait(false);

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var errorId = new Guid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");
                this._logger.LogError($"Source: {ex.Source ?? ""}");
                this._logger.LogError($"Stack-Trace {ex.StackTrace ?? ""}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();
            }
            catch (Exception ex)
            {
                var errorId = new Guid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");
                this._logger.LogError($"Source: {ex.Source ?? ""}");
                this._logger.LogError($"Stack-Trace {ex.StackTrace ?? ""}");

                ModelState.AddModelError(nameof(ex), ex.Message);
                return ValidationProblem();
            }
        }
    }
}
