using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Prestigious.Data;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<Prestigious.Data.ApplicationDbContext> options)
            : base(options)
        { }
        
        public DbSet<Prestigious.Models.Contacto> DataContacto { get; set; }
        public DbSet<Prestigious.Models.Producto> DataProducto { get; set; }
        public DbSet<Prestigious.Models.Proforma> DataItemCarrito {get; set; }
    }
