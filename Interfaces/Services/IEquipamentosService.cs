using gr2_api.Controllers.ViewModels.Request;
using gr2_api.Controllers.ViewModels.Response;
using gr2_api.Objects;

namespace gr2_api.Interfaces.Services;

public interface IEquipamentosService
{
  Task<ServiceResult<List<EquipamentosResponseViewModel>>> GetAllEquipamentosAsync();
  Task<ServiceResult<EquipamentosResponseViewModel>> GetEquipamentoByIdAsync(int id);
  Task<ServiceResult<EquipamentosResponseViewModel>> AddEquipamentoAsync(EquipamentoRequestViewModel request);
  Task<ServiceResult<EquipamentosResponseViewModel>> UpdateEquipamentoAsync(EquipamentoRequestViewModel request);
  Task<ServiceResult<bool>> DeleteEquipamentoAsync(int id);
}
