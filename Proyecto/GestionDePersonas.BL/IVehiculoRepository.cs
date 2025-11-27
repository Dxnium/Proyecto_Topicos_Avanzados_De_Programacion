using GestionDePersonas.Model;

namespace GestionDePersonas.BL
{
    public interface IVehiculoRepository
    {
        Task Create(Vehiculo vehiculo);
        Task Delete(int id);
        Task<IEnumerable<Vehiculo>> Read();
        Task Update(int id, Vehiculo vehiculo);
        Task<Vehiculo?> ObtenerVehiculoPorId(int id);
        Task<IEnumerable<Vehiculo?>> ObtenerVehiculosPorIdPersona(int id);
        Task<Vehiculo?> ObtenerVehiculoPorPlaca(string placa);
        Task AsignarPropietario(int id_vehiculo, int id_persona);

    }
}
