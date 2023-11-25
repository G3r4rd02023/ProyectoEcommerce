using Microsoft.AspNetCore.Identity;
using ProyectoEcommerce.Models;
using ProyectoEcommerce.Models.Entidades;

namespace ProyectoEcommerce.Services
{
    public interface IServicioUsuario
    {
        Task<Usuario> ObtenerUsuario(string email);
        Task<IdentityResult> CrearUsuario(Usuario usuario, string password);
        Task CrearRol(string nombreRol);
        Task AsignarRol(Usuario usuario, string nombreRol);
        Task<bool> ConfirmarRolUsuario(Usuario usuario, string roleName);
        Task<SignInResult> IniciarSesion(LoginViewModel model);
        Task CerrarSesion();
    }
}

