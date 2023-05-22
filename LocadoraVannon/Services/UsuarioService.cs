using LocadoraVannon.Models;
using LocadoraVannon.Repositories.Interfaces;
using LocadoraVannon.Services.Interfaces;

namespace LocadoraVannon.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository UsuarioRepository)
        {
            this.usuarioRepository = UsuarioRepository;
        }

        public async Task<Usuario?> ObterUsuarioAsync(int id)
        {
            return await usuarioRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuariosAsync()
        {
            return await usuarioRepository.ObterTodosAsync();
        }

        public async Task CriarUsuarioAsync(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now; 
            await usuarioRepository.AdicionarAsync(usuario);
        }

        public async Task AtualizarUsuarioAsync(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            await usuarioRepository.AtualizarAsync(usuario);
        }

        public async Task RemoverUsuarioAsync(int id)
        {
            var usuario = await usuarioRepository.ObterPorIdAsync(id);
            if (usuario != null)
            {
                await usuarioRepository.RemoverAsync(usuario);
            }
        }
    }
}
