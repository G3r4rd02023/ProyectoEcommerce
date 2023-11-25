namespace ProyectoEcommerce.Models.Entidades
{
    public class ProductoCategoria
    {
        public int Id { get; set; }

        public Producto Producto { get; set; }

        public Categoria Categoria { get; set; }
    }
}
