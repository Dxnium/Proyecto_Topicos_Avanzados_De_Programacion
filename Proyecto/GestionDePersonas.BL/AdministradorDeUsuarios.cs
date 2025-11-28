using GestionDePersonas.Model;

namespace GestionDePersonas.BL
{
    public class AdministradorDeUsuarios : IAdministradorDeUsuarios
    {
        private readonly IUsuarioRepository usuarioRepository;
        public AdministradorDeUsuarios(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Task<Usuario?> AuthUsuario(string user, string password)
        {
            return usuarioRepository.AuthUsuario(user, password);
        }
    }
}
