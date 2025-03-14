using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExemploEF.Data;
using ExemploEF.Models;

namespace ExemploEF.Controllers
{
    public class produtosController : Controller
    {
        private readonly Context _context;

        public produtosController(Context context)
        {
            _context = context;
        }

        // GET: produtoes
        public async Task<IActionResult> Index()
        {
            var context = _context.Produtos.Include(p => p.Categoria);
            return View(await context.ToListAsync());
        }

        // GET: produtoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.produtoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: produtoes/Create
        public IActionResult Create()
        {
            ViewData["categoriaid"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId");
            return View();
        }

        // POST: produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("produtoId,nome,estoque,categoriaid")] produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.produtoId = Guid.NewGuid();
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoriaid"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.categoriaid);
            return View(produto);
        }

        // GET: produtoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["categoriaid"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.categoriaid);
            return View(produto);
        }

        // POST: produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("produtoId,nome,estoque,categoriaid")] produto produto)
        {
            if (id != produto.produtoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!produtoExists(produto.produtoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoriaid"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.categoriaid);
            return View(produto);
        }

        // GET: produtoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.produtoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool produtoExists(Guid id)
        {
            return _context.Produtos.Any(e => e.produtoId == id);
        }
    }
}
