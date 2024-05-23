using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prestigious.Data;
using Prestigious.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace Prestigious.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ILogger<CarritoController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CarritoController(ILogger<CarritoController> logger,
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult IndexUltimoProductoSesion()
        {
            var producto  = Util.SessionExtensions.Get<Producto>(HttpContext.Session,"MiUltimoProducto");
            return View("UltimoProducto",producto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        public IActionResult Index()
        {
            var userIDSession = _userManager.GetUserName(User);
            if(userIDSession == null){
                TempData["Message"] = "n";
                return RedirectToAction("Index","Home");
            }
            var items = from o in _context.DataItemCarrito select o;
            items = items.Include(p => p.Producto).
                    Where(w => w.UserID.Equals(userIDSession) &&
                        w.Status.Equals("PENDIENTE"));
            var itemsCarrito = items.ToList();
            var total = itemsCarrito.Sum(c => c.Cantidad * c.Precio);

            dynamic model = new ExpandoObject();
            model.montoTotal = total;
            model.elementosCarrito = itemsCarrito;
            return View(model);
        }

        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                TempData["Message"] = "n";
                _logger.LogInformation("No existe usuario");                
                return RedirectToAction("Index","Catalogo");
            }else{
                var producto = await _context.DataProducto.FindAsync(id);
                Util.SessionExtensions.Set<Producto>(HttpContext.Session,"MiUltimoProducto", producto);
                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Precio = producto.Price;
                proforma.Cantidad = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                ViewData["Message"] = "Se Agrego al carrito";
                _logger.LogInformation("Se agrego un producto al carrito");
                return RedirectToAction("Index","Catalogo");
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCarrito = await _context.DataItemCarrito.FindAsync(id);
            _context.DataItemCarrito.Remove(itemCarrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}