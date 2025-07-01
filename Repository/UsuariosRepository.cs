using gr2_api.Interfaces.Repository;
using gr2_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gr2_api.Repository;

public class UsuariosRepository : IUsuariosRepository
{
  private readonly AppDbContext _context;

  public UsuariosRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<Usuario>> GetAllUsuariosAsync()
  {
    return await _context.Usuarios.ToListAsync();
  }

  public async Task<Usuario> GetUsuarioByIdAsync(int id)
  {
    return await _context.Usuarios.FindAsync(id);
  }

  public async Task AddUsuarioAsync(Usuario usuario)
  {
    await _context.Usuarios.AddAsync(usuario);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateUsuarioAsync(Usuario usuario)
  {
    _context.Usuarios.Update(usuario);
    await _context.SaveChangesAsync();
  }

  public async Task DeleteUsuarioAsync(int id)
  {
    var usuario = await _context.Usuarios.FindAsync(id);
    if (usuario != null)
    {
      _context.Usuarios.Remove(usuario);
      await _context.SaveChangesAsync();
    }
  }
}