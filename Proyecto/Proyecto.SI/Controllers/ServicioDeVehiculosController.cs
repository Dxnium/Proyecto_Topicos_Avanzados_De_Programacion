using GestionDePersonas.BL;
using GestionDePersonas.Model;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioDeVehiculosController : ControllerBase
    {
        private readonly IAdministradorDeVehiculos _admin;

        public ServicioDeVehiculosController(IAdministradorDeVehiculos admin)
        {
            _admin = admin;
        }

        [HttpPost("CrearVehiculo")]
        public async Task<ActionResult> CrearVehiculo([FromBody] Vehiculo vehiculo)
        {
            await _admin.Create(vehiculo);
            return Ok();
        }

        [HttpPut("ActualizarVehiculo/{id}")]
        public async Task<ActionResult> ActualizarVehiculo(int id, [FromBody] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return BadRequest("El ID del vehículo no coincide.");
            }

            var vehiculoExistente = await _admin.ObtenerPorId(id);
            if (vehiculoExistente == null)
            {
                return NotFound();
            }

            await _admin.Update(id, vehiculo);
            return Ok();
        }

        [HttpDelete("EliminarVehiculo/{id}")]
        public async Task<ActionResult> EliminarVehiculo(int id)
        {
            var vehiculoExistente = await _admin.ObtenerPorId(id);
            if (vehiculoExistente == null)
            {
                return NotFound();
            }

            await _admin.Delete(id);
            return Ok();
        }

        [HttpGet("ObtenerVehiculos")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> ObtenerVehiculos()
        {
            var vehiculos = await _admin.Read();
            return Ok(vehiculos);
        }

        [HttpGet("ObtenerVehiculoPorId/{id}")]
        public async Task<ActionResult<Vehiculo>> ObtenerVehiculoPorId(int id)
        {
            var vehiculo = await _admin.ObtenerPorId(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
        }

        [HttpGet("ObtenerVehiculoPorIdPersona/{id}")]
        public async Task<ActionResult<Vehiculo>> ObtenerVehiculoPorPlaca(int id)
        {
            var vehiculo = await _admin.ObtenerVehiculosPorIdPersona(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
        }

        [HttpPost("AsignarPropietario/{id_vehiculo}/{id_persona}")]
        public async Task<ActionResult<Vehiculo>> AsignarPropietario(int id_vehiculo, int id_persona)
        {
            await _admin.AsignarPropietario(id_vehiculo, id_persona);
            return Ok();
        }
    }
}
