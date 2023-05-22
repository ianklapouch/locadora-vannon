using LocadoraVannon.Models;

namespace LocadoraVannon.Services.Interfaces
{
    public interface IFilmeService
    {
        Task<Filme?> ObterFilmeAsync(int id);
        Task<IEnumerable<Filme>> ObterTodosFilmesAsync();
        Task CriarFilmeAsync(Filme filme);
        Task AtualizarFilmeAsync(Filme filme);
        Task RemoverFilmeAsync(int id);
    }
}
