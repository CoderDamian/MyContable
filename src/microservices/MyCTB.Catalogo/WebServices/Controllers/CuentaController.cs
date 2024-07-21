using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyCTB.Catalogo.ApplicationService;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.WebServices
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly IMediator _mediator;

        public CuentaController(ILogger<CuentaController> logger, IMediator mediator)
        {
            this._logger = logger;
            this._mediator = mediator;

            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        [HttpPost]
        public async Task<IActionResult> Add_Cuenta([FromBody] AddDTO cuentaDTO)
        {
            try
            {
                await _mediator.Send(new AddCuentaRequest(cuentaDTO)).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                _logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{offset}/{fetch}")]
        public async Task<IActionResult> Get_Plan_Cuenta(int offset, int fetch)
        {
            try
            {
                //return await _unitOfWork.CuentaContableRepository.Get_PlanDeCuentas_Async().ConfigureAwait(false);
                IEnumerable<PlanCuentasDTO> planCuentasDTO = await _mediator.Send(new CuentaList(offset, fetch)).ConfigureAwait(false);

                return Ok(planCuentasDTO);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                _logger.LogError($"Error ocurred in API: {errorId} {ex.Message}");

                //_httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                return StatusCode(StatusCodes.Status500InternalServerError);

                //return await HttpContext.Response.WriteAsJsonAsync(new
                //{
                //    ErrorId = errorId,
                //    Message = "Something bad happened in our API. " + "Contact our support team with the ErrorID if the issue persists."
                //});

                //throw;
            }
        }
    }
}