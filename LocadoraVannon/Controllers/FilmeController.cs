using Microsoft.AspNetCore.Mvc;
using LocadoraVannon.Models;
using LocadoraVannon.Services.Interfaces;

namespace LocadoraVannon.Controllers
{
    public class FilmeController : Controller
    {
        private readonly IFilmeService filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            this.filmeService = filmeService;
        }

        // GET: Filme
        public async Task<IActionResult> Index()
        {
            var filmes = await filmeService.ObterTodosFilmesAsync();

            return filmes != null
                ? View(filmes)
                : Problem("Entity set 'AppDbContext.Filmes'  is null.");
        }

        // GET: Filme/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await filmeService.ObterFilmeAsync((int)id);

            return filme != null
                   ? View(filme)
                   : NotFound();
        }

        // GET: Filme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Diretor,Ano,Genero,Sinopse")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                await filmeService.CriarFilmeAsync(filme);
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filme/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await filmeService.ObterFilmeAsync((int)id);
            return filme != null
                ? View(filme)
                : NotFound();
        }

        // POST: Filme/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Diretor,Ano,Genero,Sinopse")] Filme filme)
        {
            if (id != filme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await filmeService.AtualizarFilmeAsync(filme);
                return RedirectToAction(nameof(Index));
            }

            return View(filme);
        }

        // GET: Filme/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await filmeService.ObterFilmeAsync((int)id);
            return filme != null
                ? View(filme)
                : NotFound();
        }

        // POST: Filme/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await filmeService.RemoverFilmeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
