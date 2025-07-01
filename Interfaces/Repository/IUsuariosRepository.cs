using gr2_api.Models;

namespace gr2_api.Interfaces.Repository
{
    public interface IUsuariosRepository
    {
        Task<List<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(int id);
        Task AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}