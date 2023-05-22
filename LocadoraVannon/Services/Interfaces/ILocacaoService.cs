using LocadoraVannon.Models;

namespace LocadoraVannon.Services.Interfaces
{
    public interface ILocacaoService
    {
        Task<Locacao?> ObterLocacaoAsync(int id);
        Task<IEnumerable<Locacao>> ObterTodosLocacaosAsync();
        Task CriarLocacaoAsync(Locacao locacao);
        Task AtualizarLocacaoAsync(Locacao locacao);
        Task RemoverLocacaoAsync(int id);
    }
}
