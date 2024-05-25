using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prestigious.Models;

namespace Prestigious.Data;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        
        public DbSet<Prestigious.Models.Contacto> DataContacto { get; set; }
        public DbSet<Prestigious.Models.Producto> DataProducto { get; set; }
        public DbSet<Prestigious.Models.Proforma> DataItemCarrito {get; set; }

        public DbSet<Prestigious.Models.Pago> Pago {get; set; }
        public DbSet<Prestigious.Models.Pedido> Pedido  {get; set; }

        public DbSet<Prestigious.Models.DetallePedido> DetallePedido  {get; set; }

    }
