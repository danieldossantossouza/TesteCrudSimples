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
    public class CaminhoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaminhoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Caminhoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Caminhaoes.Include(c => c.Motorista);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Caminhoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhaoes
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // GET: Caminhoes/Create
        public IActionResult Create()
        {
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "PrimeiroNome");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Caminhao caminhao)
        {
            if (ModelState.IsValid)
            {
                caminhao.Id = Guid.NewGuid();
                _context.Add(caminhao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "PrimeiroNome", caminhao.MotoristaId);
            return View(caminhao);
        }

        // GET: Caminhoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhaoes.FindAsync(id);
            if (caminhao == null)
            {
                return NotFound();
            }
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "PrimeiroNome", caminhao.MotoristaId);
            return View(caminhao);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,Caminhao caminhao)
        {
            if (id != caminhao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caminhao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoExists(caminhao.Id))
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
            ViewData["MotoristaId"] = new SelectList(_context.Motoristas, "Id", "PrimeiroNome", caminhao.MotoristaId);
            return View(caminhao);
        }

        // GET: Caminhoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhaoes
                .Include(c => c.Motorista)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // POST: Caminhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var caminhao = await _context.Caminhaoes.FindAsync(id);
            _context.Caminhaoes.Remove(caminhao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaminhaoExists(Guid id)
        {
            return _context.Caminhaoes.Any(e => e.Id == id);
        }
    }
}
