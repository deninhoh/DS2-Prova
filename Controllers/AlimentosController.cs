using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaYagoDS2.Data;
using ProvaYagoDS2.Models;

namespace ProvaYagoDS2.Controllers
{
    public class AlimentosController : Controller
    {
        private readonly ProvaYagoDS2Context _context;

        public AlimentosController(ProvaYagoDS2Context context)
        {
            _context = context;
        }

        // GET: Alimentos
        public async Task<IActionResult> Index()
        {
            var provaYagoDS2Context = _context.Alimento.Include(a => a.Pessoa).OrderByDescending(a => a.Quantidade).Take(10);
            return View(await provaYagoDS2Context.ToListAsync());
        }

        // GET: Alimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimento = await _context.Alimento
                .Include(a => a.Pessoa)
                .FirstOrDefaultAsync(m => m.AlimentoId == id);
            if (alimento == null)
            {
                return NotFound();
            }

            return View(alimento);
        }

        // GET: Alimentos/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome");
            return View();
        }

        // POST: Alimentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlimentoId,PessoaId,Quantidade,Data")] Alimento alimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", alimento.PessoaId);
            return View(alimento);
        }

        // GET: Alimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimento = await _context.Alimento.FindAsync(id);
            if (alimento == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", alimento.PessoaId);
            return View(alimento);
        }

        // POST: Alimentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlimentoId,PessoaId,Quantidade,Data")] Alimento alimento)
        {
            if (id != alimento.AlimentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlimentoExists(alimento.AlimentoId))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "PessoaId", "Nome", alimento.PessoaId);
            return View(alimento);
        }

        // GET: Alimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimento = await _context.Alimento
                .Include(a => a.Pessoa)
                .FirstOrDefaultAsync(m => m.AlimentoId == id);
            if (alimento == null)
            {
                return NotFound();
            }

            return View(alimento);
        }

        // POST: Alimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alimento = await _context.Alimento.FindAsync(id);
            _context.Alimento.Remove(alimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlimentoExists(int id)
        {
            return _context.Alimento.Any(e => e.AlimentoId == id);
        }
    }
}
