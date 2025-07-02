using gr2_api.Interfaces.Repository;
using gr2_api.Models;
using gr2_api.Objects;
using Microsoft.EntityFrameworkCore;

namespace gr2_api.Repository
{
  public class EquipamentoRepository : IEquipamentoRepository
  {
    private readonly AppDbContext _context;

    public EquipamentoRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<RepositoryResult<List<Equipamento>>> GetAllEquipamentosAsync()
    {
      var equipamentos = await _context.Equipamentos.ToListAsync();
      if (equipamentos.Count == 0)
      {
        return RepositoryResult<List<Equipamento>>.Fail("Sem equipamentos cadastrados.");
      }
      return RepositoryResult<List<Equipamento>>.Ok(equipamentos);
    }

    public async Task<RepositoryResult<Equipamento>> GetEquipamentoByIdAsync(int id)
    {
      var equipamento = await _context.Equipamentos.FindAsync(id);
      if (equipamento == null)
      {
        return RepositoryResult<Equipamento>.Fail("Equipamento não encontrado.");
      }
      return RepositoryResult<Equipamento>.Ok(equipamento);
    }

    public async Task<RepositoryResult<Equipamento>> AddEquipamentoAsync(Equipamento equipamento)
    {
      await _context.Equipamentos.AddAsync(equipamento);
      await _context.SaveChangesAsync();
      return RepositoryResult<Equipamento>.Ok(equipamento);
    }

    public async Task<RepositoryResult<Equipamento>> UpdateEquipamentoAsync(Equipamento equipamento)
    {
      _context.Entry(equipamento).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return RepositoryResult<Equipamento>.Ok(equipamento);
    }

    public async Task<RepositoryResult<bool>> DeleteEquipamentoAsync(int id)
    {
      var equipamento = await _context.Equipamentos.FindAsync(id);
      if (equipamento != null)
      {
        _context.Equipamentos.Remove(equipamento);
        await _context.SaveChangesAsync();
        return RepositoryResult<bool>.Ok(true);
      }
      return RepositoryResult<bool>.Fail("Equipamento não encontrado.");
    }

  }
}