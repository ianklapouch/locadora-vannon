using Microsoft.AspNetCore.Mvc;
using LocadoraVannon.Models;
using LocadoraVannon.Services.Interfaces;

namespace LocadoraVannon.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var usuarios = await usuarioService.ObterTodosUsuariosAsync();
            return usuarios != null
                ? View(usuarios)
                : Problem("Entity set 'AppDbContext.Clientes'  is null.");
        }

        // GET: Usuario/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await usuarioService.ObterUsuarioAsync((int)id);

            return usuario != null
                   ? View(usuario)
                   : NotFound();
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await usuarioService.CriarUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await usuarioService.ObterUsuarioAsync((int)id);
            return usuario != null
                ? View(usuario)
                : NotFound();
        }

        // POST: Usuario/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha,DataCadastro")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await usuarioService.AtualizarUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // GET: Usuario/Delete/{id}
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await usuarioService.ObterUsuarioAsync((int)id);
            return usuario != null
                ? View(usuario)
                : NotFound();
        }

        // POST: Usuario/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await usuarioService.RemoverUsuarioAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
