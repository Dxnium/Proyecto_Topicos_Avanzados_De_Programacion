using GestionDePersonas.Model;

namespace GestionDePersonas.BL
{
    public interface IAdministradorDeVehiculos
    {
        Task Create(Vehiculo vehiculo);
        Task Delete(int id);
        Task<IEnumerable<Vehiculo>> Read();
        Task Update(int id, Vehiculo vehiculo);
        Task<IEnumerable<Vehiculo>> ObtenerVehiculosPorIdPersona(int id);
    }
}
