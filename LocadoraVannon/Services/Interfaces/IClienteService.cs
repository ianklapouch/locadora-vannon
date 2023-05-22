using LocadoraVannon.Models;

namespace LocadoraVannon.Services.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente?> ObterClienteAsync(int id);
        Task<IEnumerable<Cliente>> ObterTodosClientesAsync();
        Task CriarClienteAsync(Cliente cliente);
        Task AtualizarClienteAsync(Cliente cliente);
        Task RemoverClienteAsync(int id);
    }
}
