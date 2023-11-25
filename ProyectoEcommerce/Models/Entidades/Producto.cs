using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEcommerce.Models.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
       
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }

        [DataType(DataType.MultilineText)]        
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]        
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Precio { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]        
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Inventario { get; set; }
        public string Foto { get; set; }

        public ICollection<ProductoCategoria> ProductoCategorias { get; set; }
             
        public ICollection<DetalleVenta> DetalleVentas { get; set; }

    }
}
