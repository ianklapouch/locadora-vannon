using LocadoraVannon.Models;
using LocadoraVannon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVannon.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext context;
        public FilmeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AdicionarAsync(Filme filme)
        {
            context.Add(filme);
            await context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Filme filme)
        {
            context.Update(filme);
            await context.SaveChangesAsync();
        }

        public async Task<Filme?> ObterPorIdAsync(int id)
        {
            return await context.Filmes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Filme>> ObterTodosAsync()
        {
            return await context.Filmes.ToListAsync();
        }

        public async Task RemoverAsync(Filme filme)
        {
            context.Filmes.Remove(filme);
            await context.SaveChangesAsync();
        }
    }
}
