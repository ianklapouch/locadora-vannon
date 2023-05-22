using Microsoft.AspNetCore.Mvc;
using LocadoraVannon.Models;
using LocadoraVannon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVannon.Controllers
{
    public class LocacaoController : Controller
    {
        private readonly AppDbContext context;
        private readonly ILocacaoService locacaoService;

        public LocacaoController(ILocacaoService locacaoService, AppDbContext context)
        {
            this.locacaoService = locacaoService; 
            this.context = context;
        }

        // GET: Locacao
        public async Task<IActionResult> Index()
        {
            var locacoes = await locacaoService.ObterTodosLocacaosAsync();

            return locacoes != null
                ? View(locacoes)
                : Problem("Entity set 'AppDbContext.Locacaos'  is null.");
        }

        // GET: Locacao/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await locacaoService.ObterLocacaoAsync((int)id);

            return locacao != null
                   ? View(locacao)
                   : NotFound();
        }

        // GET: Locacao/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(context.Clientes, "Id", "Email");
            ViewData["FilmeId"] = new SelectList(context.Filmes, "Id", "Ano");
            return View();
        }

        // POST: Locacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,FilmeId,DataLocacao,DataDevolucao,ValorPago")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                await locacaoService.CriarLocacaoAsync(locacao);
                return RedirectToAction(nameof(Index));
            }
            return View(locacao);
        }

        // GET: Locacao/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await locacaoService.ObterLocacaoAsync((int)id);
            if (locacao == null)
            {
                return NotFound();
            }

            ViewData["ClienteId"] = new SelectList(context.Clientes, "Id", "Email");
            ViewData["FilmeId"] = new SelectList(context.Filmes, "Id", "Ano");
            return View(locacao);                
        }

        // POST: Locacao/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,FilmeId,DataLocacao,DataDevolucao,ValorPago")] Locacao locacao)
        {
            if (id != locacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await locacaoService.AtualizarLocacaoAsync(locacao);
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteId"] = new SelectList(context.Clientes, "Id", "Email");
            ViewData["FilmeId"] = new SelectList(context.Filmes, "Id", "Ano");

            return View(locacao);
        }

        // GET: Locacao/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await locacaoService.ObterLocacaoAsync((int)id);
            return locacao != null
                ? View(locacao)
                : NotFound();
        }

        // POST: Locacao/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await locacaoService.RemoverLocacaoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
