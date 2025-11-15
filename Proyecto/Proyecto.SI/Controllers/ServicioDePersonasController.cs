using GestionDePersonas.BL;
using GestionDePersonas.Model;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioDePersonasController : ControllerBase
    {
        private readonly IAdministradorDePersonas _admin;

        public ServicioDePersonasController(IAdministradorDePersonas admin)
        {
            _admin = admin;
        }

        [HttpPost("CrearPersona")]
        public async Task<ActionResult> CrearPersona([FromBody] Persona persona)
        {
            await _admin.Create(persona);
            return Ok();
        }

        [HttpPut("ActualizarPersona/{id}")]
        public async Task<ActionResult> ActualizarPersona(int id, [FromBody] Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest("El ID del vehículo no coincide.");
            }
            var personaExistente = await _admin.ObtenerPorId(id);
            if (personaExistente == null)
            {
                return NotFound();
            }
            await _admin.Update(id, persona);
            return Ok();
        }

        [HttpDelete("EliminarPersona/{id}")]
        public async Task<ActionResult> EliminarPersona(int id)
        {
            var personaExistente = await _admin.ObtenerPorId(id);
            if (personaExistente == null)
            {
                return NotFound();
            }
            await _admin.Delete(id);
            return Ok();
        }

        [HttpGet("ObtenerPersonas")]
        public async Task<ActionResult<IEnumerable<Persona>>> ObtenerPersonas()
        {
            var personas = await _admin.Read();
            return Ok(personas);
        }

        [HttpGet("ObtenerPersonaPorId/{id}")]
        public async Task<ActionResult<Persona>> ObtenerPersonaPorId(int id)
        {
            var persona = await _admin.ObtenerPorId(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        [HttpGet("ObtenerPersonaPorCedula/{cedula}")]
        public async Task<ActionResult<Persona>> ObtenerPersonaPorCedula(int cedula)
        {
            var persona = await _admin.ObtenerPorCedula(cedula);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }
    }
}
