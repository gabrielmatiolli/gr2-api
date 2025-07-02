using gr2_api.Models;

namespace gr2_api.Interfaces.Repository
{
    public interface IComponentesRepository
    {
        Task<List<Componente>> GetAllComponentesAsync();
        Task<Componente> GetComponenteByIdAsync(int id);
        Task AddComponenteAsync(Componente componente);
        Task UpdateComponenteAsync(Componente componente);
        Task DeleteComponenteAsync(int id);
    }
}