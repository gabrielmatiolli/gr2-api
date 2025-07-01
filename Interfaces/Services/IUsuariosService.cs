using gr2_api.Controllers.ViewModels.Request;
using gr2_api.Models;
using gr2_api.Objects;

namespace gr2_api.Interfaces.Services;

public interface IUsuariosService
{
    Task<List<Usuario>> GetAllUsuariosAsync();
    Task<Usuario> GetUsuarioByIdAsync(int id);
    Task<ServiceResult<Usuario>> AddUsuarioAsync(UsuarioRequestViewModel request);
    Task UpdateUsuarioAsync(Usuario usuario);
    Task DeleteUsuarioAsync(int id);
}
