using LocadoraVannon.Models;
using LocadoraVannon.Repositories.Interfaces;
using LocadoraVannon.Repositories;
using LocadoraVannon.Services.Interfaces;

namespace LocadoraVannon.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILocacaoRepository locacaoRepository;

        public LocacaoService(ILocacaoRepository locacaoRepository)
        {
            this.locacaoRepository = locacaoRepository;
        }

        public async Task<Locacao?> ObterLocacaoAsync(int id)
        {
            return await locacaoRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Locacao>> ObterTodosLocacaosAsync()
        {
            return await locacaoRepository.ObterTodosAsync();
        }

        public async Task CriarLocacaoAsync(Locacao locacao)
        {
            await locacaoRepository.AdicionarAsync(locacao);
        }

        public async Task AtualizarLocacaoAsync(Locacao locacao)
        {
            await locacaoRepository.AtualizarAsync(locacao);
        }

        public async Task RemoverLocacaoAsync(int id)
        {
            var locacao = await locacaoRepository.ObterPorIdAsync(id);
            if (locacao != null)
            {
                await locacaoRepository.RemoverAsync(locacao);
            }
        }
    }
}
