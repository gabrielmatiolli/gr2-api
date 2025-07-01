using gr2_api.Controllers.ViewModels.Request;
using gr2_api.Controllers.ViewModels.Response;
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
        public async Task<ActionResult<List<UsuarioResponseViewModel>>> GetAllUsuarios()
        {
            var usuarios = await _usuariosService.GetAllUsuariosAsync();
            var usuarioDtos = usuarios.Select(usuario => new UsuarioResponseViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email.ToString()
            }).ToList();
            return Ok(usuarioDtos);
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
        public async Task<ActionResult<UsuarioResponseViewModel>> CreateUsuario([FromBody] UsuarioRequestViewModel request)
        {
            var usuario = await _usuariosService.AddUsuarioAsync(request);
            if (!usuario.Success) return BadRequest(usuario.Error);

            var response = new UsuarioResponseViewModel
            {
                Id = usuario.Data.Id,
                Nome = usuario.Data.Nome,
                Email = usuario.Data.Email.ToString()
            };
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Data.Id }, response);
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