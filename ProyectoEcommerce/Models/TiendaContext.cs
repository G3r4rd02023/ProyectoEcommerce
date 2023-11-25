using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoEcommerce.Models.Entidades;

namespace ProyectoEcommerce.Models
{
    public class TiendaContext : IdentityDbContext<Usuario>
    {
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoCategoria> ProductoCategorias { get; set; }
        public DbSet<TemporalVenta> TemporalVentas { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Producto>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<ProductoCategoria>().HasIndex("ProductoId", "CategoriaId").IsUnique();
        }

        
    }
}
