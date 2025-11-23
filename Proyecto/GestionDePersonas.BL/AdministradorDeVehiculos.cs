using GestionDePersonas.BL.ReglasDeNegocio;
using GestionDePersonas.Model;

namespace GestionDePersonas.BL
{
    public class AdministradorDeVehiculos : IAdministradorDeVehiculos
    {
        private readonly IVehiculoRepository vehiculoRepository;

        public AdministradorDeVehiculos(IVehiculoRepository vehiculoRepository)
        {
            this.vehiculoRepository = vehiculoRepository;
        }

        public async Task Create(Vehiculo vehiculo)
        {
            if (!ReglasDeVehiculo.ElVehiculoEsValido(vehiculo))
            {
                throw new ArgumentException("El vehículo no es válido.");
            }

            var existente = await vehiculoRepository.ObtenerVehiculoPorPlaca(vehiculo.Placa);

            if (existente != null)
            {
                throw new ArgumentException("La placa ya está registrada en la base de datos.");
            }

            await vehiculoRepository.Create(vehiculo);
        }

        public async Task Delete(int id)
        {
            if (!ReglasDeVehiculo.ElIdEsValido(id))
            {
                throw new ArgumentException("El Id no es válido.");
            }

            await vehiculoRepository.Delete(id);
        }

        public async Task<Vehiculo?> ObtenerPorId(int id)
        {
            if (!ReglasDeVehiculo.ElIdEsValido(id))
            {
                throw new ArgumentException("El Id no es válido.");
            }

            return await vehiculoRepository.ObtenerVehiculoPorId(id);
        }

        public async Task<Vehiculo?> ObtenerPorPlaca(string placa)
        {
            if (string.IsNullOrEmpty(placa))
            {
                throw new ArgumentException("La placa no es válida.");
            }

            return await vehiculoRepository.ObtenerVehiculoPorPlaca(placa);
        }

        public async Task<IEnumerable<Vehiculo>> Read()
        {
            return await vehiculoRepository.Read();
        }

        public async Task Update(int id, Vehiculo vehiculo)
        {
            if (!ReglasDeVehiculo.ElIdEsValido(id))
                throw new ArgumentException("El Id no es válido.");

            if (!ReglasDeVehiculo.ElVehiculoEsValido(vehiculo))
                throw new ArgumentException("Los datos del vehículo no son válidos.");

            var vehiculoExistente = await vehiculoRepository.ObtenerVehiculoPorId(id);

            if (vehiculoExistente == null)
                throw new ArgumentException("El vehículo no existe.");

            var vehiculoConPlaca = await vehiculoRepository.ObtenerVehiculoPorPlaca(vehiculo.Placa);

            if (vehiculoConPlaca != null && vehiculoConPlaca.Id != id)
            {
                throw new ArgumentException("La placa ya está registrada en otro vehículo.");
            }

            await vehiculoRepository.Update(id, vehiculo);
        }

        public async Task<IEnumerable<Vehiculo>> ObtenerVehiculosPorIdPersona(int id)
        {
            if (!ReglasDePersona.ElIdEsValido(id))
            {
                throw new ArgumentException("El ID no es valido");
            }

            return await vehiculoRepository.ObtenerVehiculosPorIdPersona(id);

        }
    }
}
