using Microsoft.AspNetCore.Mvc;
using LocadoraVannon.Models;
using LocadoraVannon.Services.Interfaces;

namespace LocadoraVannon.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService clienteService;
        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            var clientes = await clienteService.ObterTodosClientesAsync();

            return clientes != null
                ? View(clientes)
                : Problem("Entity set 'AppDbContext.Clientes'  is null.");
        }
        
        // GET: Cliente/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await clienteService.ObterClienteAsync((int)id);

            return cliente != null
                   ? View(cliente)
                   : NotFound();
        }
        
        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone,Endereco")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                await clienteService.CriarClienteAsync(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
        
        // GET: Cliente/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await clienteService.ObterClienteAsync((int)id);
            return cliente != null
                ? View(cliente)
                : NotFound();
        }
        
        // POST: Cliente/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Telefone,Endereco,DataCadastro")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await clienteService.AtualizarClienteAsync(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }
        
        // GET: Cliente/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await clienteService.ObterClienteAsync((int)id);
            return cliente != null
                ? View(cliente)
                : NotFound();
        }
        
        // POST: Cliente/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await clienteService.RemoverClienteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
