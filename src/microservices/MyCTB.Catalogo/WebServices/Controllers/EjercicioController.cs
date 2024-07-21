using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MyCTB.Catalogo.ApplicationService;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.WebServices
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EjercicioController : ControllerBase
    {
        private readonly ILogger<EjercicioController> _logger;
        private readonly IMediator _mediator;

        public EjercicioController(ILogger<EjercicioController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ejerciciosDTO = await this._mediator.Send(new EjercicioList()).ConfigureAwait(false);

                return Ok(ejerciciosDTO);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get_By_ID(int id)
        {
            try
            {
                var ejercicioDTO = await this._mediator.Send(new EjercicioGetToUpdate(id)).ConfigureAwait(false);

                return Ok(ejercicioDTO);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateEjercicioDTO ejercicioDTO)
        {
            try
            {
                await this._mediator.Send(new EjercicioUpdate(ejercicioDTO)).ConfigureAwait(false);

                return NoContent();

            }
            catch (DBConcurrencyException ex)
            {
                var errorId = Guid.NewGuid();
                this._logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
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