using System.ComponentModel.DataAnnotations;

namespace ProyectoEcommerce.Models
{
    public class LoginViewModel
    {
        
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
        public string Correo { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MinLength(6, ErrorMessage = "El campo {0} debe tener al menos {1} carácteres.")]
        public string Password { get; set; }

        [Display(Name = "Recordarme en este navegador")]
        public bool Recuerdame { get; set; }

    }
}
