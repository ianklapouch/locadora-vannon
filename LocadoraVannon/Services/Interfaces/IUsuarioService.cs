using LocadoraVannon.Models;

namespace LocadoraVannon.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> ObterUsuarioAsync(int id);
        Task<IEnumerable<Usuario>> ObterTodosUsuariosAsync();
        Task CriarUsuarioAsync(Usuario usuario);
        Task AtualizarUsuarioAsync(Usuario usuario);
        Task RemoverUsuarioAsync(int id);
    }
}
