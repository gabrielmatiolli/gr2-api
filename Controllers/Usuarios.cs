using gr2_api.Models;
using gr2_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gr2_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _usuariosService;

        public UsuariosController(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetAllUsuarios()
        {
            var usuarios = await _usuariosService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _usuariosService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            var result = await _usuariosService.AddUsuarioAsync(usuario);

            if (!result.Success)
            {
                return BadRequest(result.Error);
            }
            
            return CreatedAtAction(nameof(GetUsuarioById), new { id = result.Data.Id }, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            await _usuariosService.UpdateUsuarioAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            await _usuariosService.DeleteUsuarioAsync(id);
            return NoContent();
        }
    }
}