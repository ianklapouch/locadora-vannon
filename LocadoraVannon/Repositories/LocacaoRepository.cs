using LocadoraVannon.Models;
using LocadoraVannon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVannon.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly AppDbContext context;
        public LocacaoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AdicionarAsync(Locacao locacao)
        {
            context.Add(locacao);
            await context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Locacao locacao)
        {
            context.Update(locacao);
            await context.SaveChangesAsync();
        }

        public async Task<Locacao?> ObterPorIdAsync(int id)
        {
            return await context.Locacoes
                    .Include(l => l.Cliente)
                    .Include(l => l.Filme)
                    .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Locacao>> ObterTodosAsync()
        {

            return await context.Locacoes.Include(l => l.Cliente).Include(l => l.Filme).ToListAsync();
        }

        public async Task RemoverAsync(Locacao locacao)
        {
            context.Locacoes.Remove(locacao);
            await context.SaveChangesAsync();
        }
    }
}
