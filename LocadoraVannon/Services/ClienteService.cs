using LocadoraVannon.Models;
using LocadoraVannon.Repositories.Interfaces;
using LocadoraVannon.Services.Interfaces;

namespace LocadoraVannon.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public async Task<Cliente?> ObterClienteAsync(int id)
        {
            return await clienteRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Cliente>> ObterTodosClientesAsync()
        {
            return await clienteRepository.ObterTodosAsync();
        }

        public async Task CriarClienteAsync(Cliente cliente)
        {
            cliente.DataCadastro = DateTime.Now;
            await clienteRepository.AdicionarAsync(cliente);
        }

        public async Task AtualizarClienteAsync(Cliente cliente)
        {
            cliente.DataCadastro = DateTime.Now;
            await clienteRepository.AtualizarAsync(cliente);
        }

        public async Task RemoverClienteAsync(int id)
        {
            var cliente = await clienteRepository.ObterPorIdAsync(id);
            if (cliente != null)
            {
                await clienteRepository.RemoverAsync(cliente);
            }
        }
    }

}
