using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EcommerceAvessoBrecho.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult PesquisaProduto()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
