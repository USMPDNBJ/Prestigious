using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Prestigious.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotNull]
        public String? Name { get; set; }
        [NotNull]
        public Decimal Price { get; set; }
        [NotNull]
        public String? Descripcion { get; set; }
        [NotNull]
        public String? Tipo { get; set; }
        [NotNull]
        public String? Size { get; set; }
        [NotNull]
        public String? ImageURL { get; set; }


    }
}