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
    public class MotoristasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotoristasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Motoristas
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.Motoristas.ToListAsync());
        }

        // GET: Motoristas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // GET: Motoristas/Create
        public IActionResult Create()
        {
            //ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "Id", "NomeRua");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                motorista.Id = Guid.NewGuid();
                _context.Add(motorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }

          
            return View(motorista);
		}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Motorista motorista)
        {
            if (id != motorista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            { 
                try
                {
                    _context.Update(motorista);
                    _context.Update(motorista.Endereco.NomeRua);


                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristaExists(motorista.Id))
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
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motoristas
                 .FirstOrDefaultAsync(m => m.Id == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var motorista = await _context.Motoristas.FindAsync(id);
            _context.Motoristas.Remove(motorista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoristaExists(Guid id)
        {
            return _context.Motoristas.Any(e => e.Id == id);
        }
    }
}
