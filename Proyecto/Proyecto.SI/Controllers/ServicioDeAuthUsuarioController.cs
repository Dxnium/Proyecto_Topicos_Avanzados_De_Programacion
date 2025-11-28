using GestionDePersonas.BL;
using Microsoft.AspNetCore.Mvc;
using Proyecto.SI.DAO;

namespace Proyecto.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioDeAuthUsuarioController : ControllerBase
    {
        private readonly IAdministradorDeUsuarios _admin;

        public ServicioDeAuthUsuarioController(IAdministradorDeUsuarios admin)
        {
            _admin = admin;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> CrearPersona([FromBody] UsuarioDAO usuario)
        {
            var user = await _admin.AuthUsuario(usuario.user, usuario.password);
            if (user == null)
            {
                return BadRequest("User o contrasena no son correctos");
            }
            return Ok();
        }

    }
}
