using gr2_api.Controllers.ViewModels.Request;
using gr2_api.Controllers.ViewModels.Response;
using gr2_api.Interfaces.Repository;
using gr2_api.Interfaces.Services;
using gr2_api.Models;
using gr2_api.Objects;

namespace gr2_api.Services
{
    public class EquipamentosService: IEquipamentosService
    {
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentosService(IEquipamentoRepository equipamentoRepository)
        {
            _equipamentoRepository = equipamentoRepository;
        }

        public async Task<ServiceResult<List<EquipamentosResponseViewModel>>> GetAllEquipamentosAsync()
        {
            var equipamentos = await _equipamentoRepository.GetAllEquipamentosAsync();
            if (!equipamentos.Success) return ServiceResult<List<EquipamentosResponseViewModel>>.Fail(equipamentos.Error);
            return ServiceResult<List<EquipamentosResponseViewModel>>.Ok([.. equipamentos.Data.Select(e => new EquipamentosResponseViewModel
            {
                Id = e.Id,
                Nome = e.Nome
            })]);
        }

        public async Task<ServiceResult<EquipamentosResponseViewModel>> GetEquipamentoByIdAsync(int id)
        {
            var equipamento = await _equipamentoRepository.GetEquipamentoByIdAsync(id);
            if (!equipamento.Success) return ServiceResult<EquipamentosResponseViewModel>.Fail(equipamento.Error);
            return ServiceResult<EquipamentosResponseViewModel>.Ok(new EquipamentosResponseViewModel
            {
                Id = equipamento.Data.Id,
                Nome = equipamento.Data.Nome
            });
        }

        public async Task<ServiceResult<EquipamentosResponseViewModel>> AddEquipamentoAsync(EquipamentoRequestViewModel request)
        {
            var equipamento = new Equipamento
            {
                Nome = request.Nome
            };
            await _equipamentoRepository.AddEquipamentoAsync(equipamento);
            return ServiceResult<EquipamentosResponseViewModel>.Ok(new EquipamentosResponseViewModel
            {
                Id = equipamento.Id,
                Nome = equipamento.Nome
            });
        }

        public async Task<ServiceResult<EquipamentosResponseViewModel>> UpdateEquipamentoAsync(EquipamentoRequestViewModel request)
        {
            var equipamento = new Equipamento
            {
                Nome = request.Nome
            };
            await _equipamentoRepository.UpdateEquipamentoAsync(equipamento);
            return ServiceResult<EquipamentosResponseViewModel>.Ok(new EquipamentosResponseViewModel
            {
                Id = equipamento.Id,
                Nome = equipamento.Nome
            });
        }

        public async Task<ServiceResult<bool>> DeleteEquipamentoAsync(int id)
        {
            var equipamento = await _equipamentoRepository.GetEquipamentoByIdAsync(id);
            if (!equipamento.Success)
            {
                await _equipamentoRepository.DeleteEquipamentoAsync(id);
                return ServiceResult<bool>.Ok(true);
            }
            return ServiceResult<bool>.Fail(equipamento.Error);
        }
    }
}