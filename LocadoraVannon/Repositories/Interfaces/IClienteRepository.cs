using LocadoraVannon.Models;

namespace LocadoraVannon.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> ObterPorIdAsync(int id);
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task AdicionarAsync(Cliente cliente);
        Task AtualizarAsync(Cliente cliente);
        Task RemoverAsync(Cliente cliente);
    }
}
