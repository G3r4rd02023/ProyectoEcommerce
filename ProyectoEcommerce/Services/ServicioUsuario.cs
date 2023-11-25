using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoEcommerce.Models;
using ProyectoEcommerce.Models.Entidades;

namespace ProyectoEcommerce.Services
{
    public class ServicioUsuario : IServicioUsuario
    {

        private readonly TiendaContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Usuario> _signInManager;

        public ServicioUsuario(TiendaContext context, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager, SignInManager<Usuario> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task AsignarRol(Usuario usuario, string nombreRol)
        {
            await _userManager.AddToRoleAsync(usuario, nombreRol);

        }

        public async Task<bool> ConfirmarRolUsuario(Usuario usuario, string roleName)
        {
            return await _userManager.IsInRoleAsync(usuario, roleName);
        }

        public async Task<IdentityResult> CrearUsuario(Usuario usuario, string password)
        {
            return await _userManager.CreateAsync(usuario, password);

        }

        public async Task CrearRol(string nombreRol)
        {
            bool rolExiste = await _roleManager.RoleExistsAsync(nombreRol);
            if (!rolExiste)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = nombreRol
                });
            }
        }

        public async Task<Usuario> ObtenerUsuario(string email)
        {
            {
                return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            }
        }

        public async Task<SignInResult> IniciarSesion(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
            model.Correo,
            model.Password,
            model.Recuerdame,
            false);
        }
        public async Task CerrarSesion()
        {
            await _signInManager.SignOutAsync();
        }

    }
}


