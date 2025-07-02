using gr2_api.Interfaces.Repository;
using gr2_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gr2_api.Repository
{
  public class ComponentesRepository : IComponentesRepository
  {
    private readonly AppDbContext _context;

    public ComponentesRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<List<Componente>> GetAllComponentesAsync()
    {
      return await _context.Componentes.ToListAsync();
    }

    public async Task<Componente> GetComponenteByIdAsync(int id)
    {
      return await _context.Componentes.FindAsync(id);
    }

    public async Task AddComponenteAsync(Componente componente)
    {
      await _context.Componentes.AddAsync(componente);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateComponenteAsync(Componente componente)
    {
      _context.Componentes.Update(componente);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteComponenteAsync(int id)
    {
      var componente = await _context.Componentes.FindAsync(id);
      if (componente != null)
      {
        _context.Componentes.Remove(componente);
        await _context.SaveChangesAsync();
      }
    }
  }
}