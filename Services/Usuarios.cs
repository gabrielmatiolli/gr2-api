using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gr2_api.Models;
using gr2_api.Objects;
using gr2_api.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace gr2_api.Services
{
    public class UsuariosService
    {
        private readonly AppDbContext _context;

        public UsuariosService(AppDbContext context)
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

        public async Task<ServiceResult<Usuario>> AddUsuarioAsync(Usuario usuario)
        {
            var existingUsuario = await _context.Usuarios
        .FirstOrDefaultAsync(u => u.Email == usuario.Email);

            if (existingUsuario != null)
            {
                return ServiceResult<Usuario>.Fail("Usuário já existe com este email.");
            }

            var emailResult = Email.Create(usuario.Email.ToString());
            if (!emailResult.IsSuccess)
            {
                return ServiceResult<Usuario>.Fail(emailResult.Error);
            }

            usuario.Email = emailResult.Value;

            var senhaResult = Senha.Create(usuario.Senha.ToString());
            if (!senhaResult.IsSuccess)
            {
                return ServiceResult<Usuario>.Fail(senhaResult.Error);
            }

            usuario.Senha = senhaResult.Value;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return ServiceResult<Usuario>.Ok(usuario);
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
}