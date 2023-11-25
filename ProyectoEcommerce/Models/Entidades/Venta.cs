using ProyectoEcommerce.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEcommerce.Models.Entidades
{
    public class Venta
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]       
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Fecha { get; set; }

        public Usuario Usuario { get; set; }


        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; } = null;

        public EstadoOrden EstadoOrden { get; set; }

        public ICollection<DetalleVenta> DetalleVentas { get; set; }
       

        [DisplayFormat(DataFormatString = "{0:N2}")]        
        public int Cantidad => DetalleVentas == null ? 0 : DetalleVentas.Sum(dv => dv.Cantidad);

        [DisplayFormat(DataFormatString = "{0:C2}")]        
        public decimal Total => DetalleVentas == null ? 0 : DetalleVentas.Sum(dv => dv.Total);
    }
}
