using GestionDePersonas.BL;
using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionDePersonas.DA
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly DBContexto _context;

        public VehiculoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task Create(Vehiculo vehiculo)
        {
            await _context.Vehiculos.AddAsync(vehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var vehiculo = await ObtenerVehiculoPorId(id);

            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Vehiculo?> ObtenerVehiculoPorId(int id)
        {
            return _context.Vehiculos
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public Task<Vehiculo?> ObtenerVehiculoPorPlaca(string placa)
        {
            return _context.Vehiculos
                .FirstOrDefaultAsync(v => v.Placa == placa);
        }

        public async Task<IEnumerable<Vehiculo?>> ObtenerVehiculosPorIdPersona(int personaId)
        {
            return await _context.Vehiculos
                .Where(v => v.PersonaId == personaId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vehiculo>> Read()
        {
            return await _context.Vehiculos
                .ToListAsync();
        }

        public async Task Update(int id, Vehiculo vehiculo)
        {
            var vehiculoDB = await ObtenerVehiculoPorId(id);

            if (vehiculoDB != null)
            {
                vehiculoDB.PersonaId = vehiculo.PersonaId;
                vehiculoDB.Placa = vehiculo.Placa;
                vehiculoDB.Marca = vehiculo.Marca;
                vehiculoDB.Modelo = vehiculo.Modelo;
                vehiculoDB.Anio = vehiculo.Anio;

                _context.Vehiculos.Update(vehiculoDB);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AsignarPropietario(int id_vehiculo, int id_persona)
        {
            var vehiculoDB = await ObtenerVehiculoPorId(id_vehiculo);

            if (vehiculoDB != null)
            {
                vehiculoDB.PersonaId = id_persona;

                _context.Vehiculos.Update(vehiculoDB);
                await _context.SaveChangesAsync();
            }
        }
    }
}
