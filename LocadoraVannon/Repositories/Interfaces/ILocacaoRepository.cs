using LocadoraVannon.Models;

namespace LocadoraVannon.Repositories.Interfaces
{
    public interface ILocacaoRepository
    {
        Task<Locacao?> ObterPorIdAsync(int id);
        Task<IEnumerable<Locacao>> ObterTodosAsync();
        Task AdicionarAsync(Locacao locacao);
        Task AtualizarAsync(Locacao locacao);
        Task RemoverAsync(Locacao locacao);
    }
}
