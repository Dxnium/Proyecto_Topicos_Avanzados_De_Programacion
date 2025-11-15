using GestionDePersonas.Model;

namespace GestionDePersonas.BL
{
    public interface IPersonaRepository
    {
        Task Create(Persona persona);
        Task Delete(int id);
        Task<IEnumerable<Persona>> Read();
        Task Update (int id, Persona persona);
        Task<Persona?> ObtenerPorCedula(int cedula);
        Task<Persona?> ObtenerPorId(int id);
    }
}
