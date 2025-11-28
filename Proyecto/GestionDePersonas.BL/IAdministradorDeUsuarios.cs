using GestionDePersonas.Model;

namespace GestionDePersonas.BL
{
    public interface IAdministradorDeUsuarios
    {
        Task<Usuario?> AuthUsuario(string user, string password);
    }
}
