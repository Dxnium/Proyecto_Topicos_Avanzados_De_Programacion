using GestionDePersonas.BL;
using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionDePersonas.DA
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DBContexto _context;

        public UsuarioRepository(DBContexto context)
        {
            _context = context;
        }
        public async Task<Usuario?> AuthUsuario(string user, string password)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == user || u.Codigo == user);

            if (usuario == null)
            {
                return null;
            }

            if (usuario.Contrasena != password)
            {
                return null;
            }

            return usuario;
        }
    }
}
