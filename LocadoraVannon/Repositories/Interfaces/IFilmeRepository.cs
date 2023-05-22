using LocadoraVannon.Models;

namespace LocadoraVannon.Repositories.Interfaces
{
    public interface IFilmeRepository
    {
        Task<Filme?> ObterPorIdAsync(int id);
        Task<IEnumerable<Filme>> ObterTodosAsync();
        Task AdicionarAsync(Filme filme);
        Task AtualizarAsync(Filme filme);
        Task RemoverAsync(Filme filme);
    }
}
