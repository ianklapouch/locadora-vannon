using LocadoraVannon.Models;

namespace LocadoraVannon.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObterPorIdAsync(int id);
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task RemoverAsync(Usuario usuario);
    }
}
