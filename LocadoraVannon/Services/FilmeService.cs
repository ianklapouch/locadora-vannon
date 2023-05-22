using LocadoraVannon.Models;
using LocadoraVannon.Repositories.Interfaces;
using LocadoraVannon.Services.Interfaces;

namespace LocadoraVannon.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
        {
            this.filmeRepository = filmeRepository;
        }

        public async Task<Filme?> ObterFilmeAsync(int id)
        {
            return await filmeRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Filme>> ObterTodosFilmesAsync()
        {
            return await filmeRepository.ObterTodosAsync();
        }

        public async Task CriarFilmeAsync(Filme filme)
        {
            filme.DataCadastro = DateTime.Now;
            await filmeRepository.AdicionarAsync(filme);
        }

        public async Task AtualizarFilmeAsync(Filme filme)
        {
            filme.DataCadastro = DateTime.Now;
            await filmeRepository.AtualizarAsync(filme);
        }

        public async Task RemoverFilmeAsync(int id)
        {
            var filme = await filmeRepository.ObterPorIdAsync(id);
            if (filme != null)
            {
                await filmeRepository.RemoverAsync(filme);
            }
        }
    }
}
