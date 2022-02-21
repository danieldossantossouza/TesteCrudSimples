using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreCrud.Data;
using AspNetCoreCrud.Models;

namespace AspNetCoreCrud.Controllers
{
    public class CadastroViagensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CadastroViagensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CadastroViagens
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CadastroViagens.Include(c => c.Motorista);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CadastroViagens/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroViagem = await _context.CadastroViagens
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroViagem == null)
            {
                return NotFound();
            }

            return View(cadastroViagem);
        }

        // GET: CadastroViagens/Create
        public IActionResult Create()
        {
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "PrimeiroNome");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CadastroViagem cadastroViagem)
        {
            if (ModelState.IsValid)
            {
                cadastroViagem.Id = Guid.NewGuid();
                _context.Add(cadastroViagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "PrimeiroNome", cadastroViagem.MotoristaId);
            return View(cadastroViagem);
        }

        // GET: CadastroViagens/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroViagem = await _context.CadastroViagens.FindAsync(id);
            if (cadastroViagem == null)
            {
                return NotFound();
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "PrimeiroNome", cadastroViagem.MotoristaId);
            return View(cadastroViagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CadastroViagem cadastroViagem)
        {
            if (id != cadastroViagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroViagem);
                    

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroViagemExists(cadastroViagem.Id))
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
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "PrimeiroNome", cadastroViagem.MotoristaId);
            return View(cadastroViagem);
        }

        // GET: CadastroViagens/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroViagem = await _context.CadastroViagens
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroViagem == null)
            {
                return NotFound();
            }

            return View(cadastroViagem);
        }

        // POST: CadastroViagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cadastroViagem = await _context.CadastroViagens.FindAsync(id);
            _context.CadastroViagens.Remove(cadastroViagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroViagemExists(Guid id)
        {
            return _context.CadastroViagens.Any(e => e.Id == id);
        }
    }
}
