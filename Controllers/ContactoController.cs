using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prestigious.Models;
using Prestigious.Data;
using Microsoft.Extensions.ML;
using Prestigious;
using Microsoft.OpenApi.Models;

namespace Prestigious.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ILogger<ContactoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly PredictionEnginePool<MLModel1.ModelInput, MLModel1.ModelOutput> _predictionEnginePool;

        public ContactoController(ILogger<ContactoController> logger, ApplicationDbContext context, PredictionEnginePool<MLModel1.ModelInput, MLModel1.ModelOutput> predictionEnginePool)
        {
            _logger = logger;
            _context = context;
            _predictionEnginePool = predictionEnginePool;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarMensaje(Contacto objContacto)
        {
            _logger.LogDebug("Ingreso a Enviar Mensaje");

            // Analizar el sentimiento del mensaje del contacto
            MLModel1.ModelInput modelInput = new MLModel1.ModelInput()
            {
                Comentario = objContacto.Message // Usar el mensaje del objeto contacto
            };

            MLModel1.ModelOutput prediction = _predictionEnginePool.Predict(modelInput);
            objContacto.Predicho = prediction.PredictedLabel;

            ViewData["Sentimiento"] = prediction.PredictedLabel;
            ViewData["Score"] = prediction.Score[1];

            if (prediction.PredictedLabel == 1)
            {
                ViewData["Mensaje"] = "Muchas gracias por su comentario, aquí en Prestigious nos esforzamos por seguir mejorando su experiencia.";
            }
            else
            {
                ViewData["Mensaje"] = "Muchas gracias por su comentario, siempre lo tomamos en cuenta, nos esforzaremos para que no vuelva a ocurrir, muchas gracias y que tenga buen día.";
            }

            // Guardar el contacto en la base de datos con el sentimiento predicho
            _context.Add(objContacto);
            _context.SaveChanges();
            ViewData["Message"] = "Se registró el contacto";

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
