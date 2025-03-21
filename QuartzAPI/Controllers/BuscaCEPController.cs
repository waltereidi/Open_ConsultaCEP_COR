
using BuscaCEP_DLL;
using BuscaCEP_DLL.Infra;
using BuscaCEP_DLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Quartz;

namespace QuartzAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuscaCEPController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;
        public BuscaCEPController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        
        [HttpGet]
        [Route("IniciarAtualizacaoDB")]
        public async Task<IActionResult> IniciarAtualizacaoDB()
        {
            var scheduler = new QuartzScheduler();
            scheduler.Start().Wait();
            var jobs = scheduler._scheduler.GetJobGroupNames().Result;
            return Ok("Serviço INICIADO , acompanhe pelo console sua execucao");

        }
    }
}
