using LocadoraVannon.Models;
using LocadoraVannon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVannon.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext context;
        public UsuarioRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            
            context.Add(usuario);
            await context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            context.Update(usuario);
            await context.SaveChangesAsync();
        }

        public async Task<Usuario?> ObterPorIdAsync(int id)
        {
            return await context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAsync()
        {
            return await context.Usuarios.ToListAsync();
        }

        public async Task RemoverAsync(Usuario usuario)
        {
            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();
        }
    }
}
