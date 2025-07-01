using gr2_api.Controllers.ViewModels.Request;
using gr2_api.Interfaces.Repository;
using gr2_api.Interfaces.Services;
using gr2_api.Models;
using gr2_api.Objects;

namespace gr2_api.Services
{
    public class UsuariosService: IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuariosRepository.GetAllUsuariosAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _usuariosRepository.GetUsuarioByIdAsync(id);
        }

        public async Task<ServiceResult<Usuario>> AddUsuarioAsync(UsuarioRequestViewModel request)
        {
            var emailResult = Email.Create(request.Email);
            if (!emailResult.IsSuccess)
                return ServiceResult<Usuario>.Fail(emailResult.Error);

            var senhaResult = Senha.Create(request.Senha);
            if (!senhaResult.IsSuccess)
                return ServiceResult<Usuario>.Fail(senhaResult.Error);

            var usuario = new Usuario
            {
                Id = 0,
                Nome = request.Nome,
                Email = emailResult.Value,
                Senha = senhaResult.Value
            };

            await _usuariosRepository.AddUsuarioAsync(usuario);
            return ServiceResult<Usuario>.Ok(usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _usuariosRepository.UpdateUsuarioAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _usuariosRepository.DeleteUsuarioAsync(id);
        }
    }
}