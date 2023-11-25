using Microsoft.AspNetCore.Identity;
using ProyectoEcommerce.Enums;
using ProyectoEcommerce.Models;
using ProyectoEcommerce.Models.Entidades;
using ProyectoEcommerce.Services;

namespace ProyectoEcommerce.Data
{
    public class SeedDb
    {
        private readonly TiendaContext _context;
        private readonly IServicioUsuario _servicioUsuario;

        public SeedDb(TiendaContext context, IServicioUsuario servicioUsuario)
        {
            _context = context;
            _servicioUsuario = servicioUsuario;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CrearCategoriasAsync();
            await CrearRolesAsync();
            await CrearUsuariosAsync( "Tecnologers", "tecnologerhn@gmail.com", "33077964",
            TipoUsuario.Administrador);
        }

        private async Task CrearRolesAsync()
        {
            await _servicioUsuario.CrearRol(TipoUsuario.Administrador.ToString());
            await _servicioUsuario.CrearRol(TipoUsuario.Cliente.ToString());
        }

        private async Task<Usuario> CrearUsuariosAsync(
        string nombreCompleto,        
        string email,
        string phone,        
        TipoUsuario tipoUsuario)
        {
            Usuario usuario = await _servicioUsuario.ObtenerUsuario(email);
            if (usuario == null)
            {
                usuario = new Usuario
                {
                    NombreCompleto = nombreCompleto,                    
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,                                        
                    TipoUsuario= tipoUsuario,
                };
                await _servicioUsuario.CrearUsuario(usuario, "123456");
                await _servicioUsuario.AsignarRol(usuario, tipoUsuario.ToString());
            }
            return usuario;
        }

        private async Task CrearCategoriasAsync()
        {
            if (!_context.Categorias.Any())
            {
                _context.Categorias.Add(new Categoria { Nombre = "Tecnología" });
                _context.Categorias.Add(new Categoria { Nombre = "Ropa" });
                _context.Categorias.Add(new Categoria { Nombre = "Gamer" });
                _context.Categorias.Add(new Categoria { Nombre = "Belleza" });
                _context.Categorias.Add(new Categoria { Nombre = "Nutrición" });
            }

            await _context.SaveChangesAsync();
        }
    }
}
