using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController : ControllerBase
    {
        private readonly ILogger<DummyController> _logger;

        public DummyController(ILogger<DummyController> logger)
        {
            _logger = logger;
        }

        [HttpGet("info")]
        [FeatureGate(FeatureFlags.GetInfoFeature)]
        public IActionResult GetInfo()
        {
            return new OkObjectResult(new
            {
                Info = "Awesome info"
            });
        }
    }
}