using System.ComponentModel.DataAnnotations;

namespace ProyectoEcommerce.Models.Entidades
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        public Venta Venta { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; } = null;

        public Producto Producto { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]        
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Cantidad { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]        
        public decimal Total => Producto == null ? 0 : (decimal)Cantidad * Producto.Precio;
    }
}
