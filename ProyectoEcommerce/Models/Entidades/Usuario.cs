using Microsoft.AspNetCore.Identity;
using ProyectoEcommerce.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEcommerce.Models.Entidades
{
    public class Usuario : IdentityUser
    {        

        [Display(Name = "Usuario")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NombreCompleto { get; set; }
                   
        public string Foto { get; set; }
               
        public TipoUsuario TipoUsuario { get; set; }
        
        public ICollection<Venta> Ventas { get; set; }
    }
}
