using gr2_api.Interfaces.Repository;
using gr2_api.Interfaces.Services;
using gr2_api.Models;

namespace gr2_api.Services
{
  public class ComponentesService : IComponentesService
  {
    private readonly IComponentesRepository _componentesRepository;

    public ComponentesService(IComponentesRepository componentesRepository)
    {
      _componentesRepository = componentesRepository;
    }

    public async Task<List<Componente>> GetAllComponentesAsync()
    {
      return await _componentesRepository.GetAllComponentesAsync();
    }

    public async Task<Componente> GetComponenteByIdAsync(int id)
    {
      return await _componentesRepository.GetComponenteByIdAsync(id);
    }

    public async Task AddComponenteAsync(Componente componente)
    {
      await _componentesRepository.AddComponenteAsync(componente);
    }

    public async Task UpdateComponenteAsync(Componente componente)
    {
      await _componentesRepository.UpdateComponenteAsync(componente);
    }

    public async Task DeleteComponenteAsync(int id)
    {
      await _componentesRepository.DeleteComponenteAsync(id);
    }
  }
}
