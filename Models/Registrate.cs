using System.ComponentModel.DataAnnotations;

namespace Prestigious.Models
{
    public class Registrate
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string? Nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        public string? ApellidoPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required]
        public string? ApellidoMaterno { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string? Email { get; set; }

        [Display(Name = "Contrasena")]
        [Required]
        public string? Contrasena { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Required]
        public string? ConfirmarContrasena { get; set; }



    }
}