using Microsoft.AspNetCore.Mvc;
using Prestigious.Models;





namespace Prestigious.Controllers
{
    public class RegistrateController : Controller
    {
        private readonly ILogger<RegistrateController> _logger;

        public RegistrateController(ILogger<RegistrateController> logger)
        {
            _logger = logger;
        }

        public IActionResult Registrate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Nombre,ApellidoPaterno,ApellidoMaterno,Email,Contrasena,ConfirmarContrasena")] Registrate registrate)
        {
            if (ModelState.IsValid)
            {
                ViewData["Message"] = "Su registro fue exitoso";

                return View("Registrate");
            }
            return View("Registrate");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}