using GestionDePersonas.Model;

namespace GestionDePersonas.BL
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> AuthUsuario(string user, string password);
    }
}
