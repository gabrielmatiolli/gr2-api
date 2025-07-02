using gr2_api.Models;
using gr2_api.Objects;

namespace gr2_api.Interfaces.Repository
{
  public interface IEquipamentoRepository
  {
    Task<RepositoryResult<List<Equipamento>>> GetAllEquipamentosAsync();
    Task<RepositoryResult<Equipamento>> GetEquipamentoByIdAsync(int id);
    Task<RepositoryResult<Equipamento>> AddEquipamentoAsync(Equipamento equipamento);
    Task<RepositoryResult<Equipamento>> UpdateEquipamentoAsync(Equipamento equipamento);
    Task<RepositoryResult<bool>> DeleteEquipamentoAsync(int id);
  }
}