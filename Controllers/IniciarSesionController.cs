using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Prestigious.Controllers
{
    [Route("[controller]")]
    public class IniciarSesionControllerñ : Controller
    {
        private readonly ILogger<IniciarSesionControllerñ> _logger;

        public IniciarSesionControllerñ(ILogger<IniciarSesionControllerñ> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}