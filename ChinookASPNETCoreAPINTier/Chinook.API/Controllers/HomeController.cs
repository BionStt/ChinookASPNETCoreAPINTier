using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chinook.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            try
            {
                var uri = new Uri("/swagger", UriKind.Relative);
                return Redirect(uri.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception-Home-Index");
                return StatusCode(500, ex);
            }
        }
    }
}