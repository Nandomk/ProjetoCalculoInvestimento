using CalculoInvestimento.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CalculoInvestimento.Api.Controllers
{
    /// <summary>
    /// Retorna lista de investimentos
    /// </summary>
    [Produces("application/json")]
    [Route("v{version:apiVersion}/TodosInvestimentos")]
    [ApiController]
    public class TodosInvestimentosController : Controller
    {
        private readonly ILogger<TodosInvestimentosController> _logger;
        private readonly IInvestimentosServices _services;
        public TodosInvestimentosController(
            ILogger<TodosInvestimentosController> logger,
            IInvestimentosServices services
            )
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _services.Get();
            return this.Ok(result);
        }
    }
}