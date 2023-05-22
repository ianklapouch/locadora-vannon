using LocadoraVannon.Models;
using LocadoraVannon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVannon.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext context;
        public ClienteRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AdicionarAsync(Cliente cliente)
        {
            context.Add(cliente);
            await context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            context.Update(cliente);
            await context.SaveChangesAsync();
        }

        public async Task<Cliente?> ObterPorIdAsync(int id)
        {
            return await context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            return await context.Clientes.ToListAsync();
        }

        public async Task RemoverAsync(Cliente cliente)
        {
            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();
        }
    }
}
