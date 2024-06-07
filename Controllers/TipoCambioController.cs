using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prestigious.Integration.currencyexchange;
using Prestigious.Integration.currencyexchange.dto;
using Prestigious.Integration.nytimes;

namespace Prestigious.Controllers
{
    public class TipoCambioController : Controller
    {
        private readonly ILogger<TipoCambioController> _logger;
        private readonly CurrencyExchangeApiIntegration _currency;
        private readonly NYTimesApiIntegration _lista;

        public TipoCambioController(ILogger<TipoCambioController> logger,
        CurrencyExchangeApiIntegration currency, NYTimesApiIntegration lista)
        {
            _logger = logger;
            _currency = currency;
            _lista = lista;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Exchange(TipoCambio? tipoCambio)
        {
            double rate = await _currency.GetExchangeRate(tipoCambio.From, tipoCambio.To);            
            var cambio = tipoCambio.Cantidad * rate;
            _logger.LogInformation($"Tipo de cambio de {tipoCambio.From} a {tipoCambio.To} es {rate} y cambio {cambio}");
            ViewData["rate"] = String.Format("{0:F2}", rate);
            ViewData["cambio"] = String.Format("{0:N2}", cambio); 
            return View("Index");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}