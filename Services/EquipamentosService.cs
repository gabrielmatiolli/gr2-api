using gr2_api.Models;
using gr2_api.Repository;
using Microsoft.EntityFrameworkCore;

namespace gr2_api.Services
{
    public class EquipamentosService
    {
        private readonly AppDbContext _context;

        public EquipamentosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Equipamento>> GetAllEquipamentosAsync()
        {
            return await _context.Equipamentos.ToListAsync();
        }

        public async Task<Equipamento> GetEquipamentoByIdAsync(int id)
        {
            return await _context.Equipamentos.FindAsync(id);
        }

        public async Task AddEquipamentoAsync(Equipamento equipamento)
        {
            _context.Equipamentos.Add(equipamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEquipamentoAsync(Equipamento equipamento)
        {
            _context.Equipamentos.Update(equipamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEquipamentoAsync(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id);
            if (equipamento != null)
            {
                _context.Equipamentos.Remove(equipamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}