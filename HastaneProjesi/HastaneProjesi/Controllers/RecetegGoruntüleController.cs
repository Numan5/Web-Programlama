using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneProjesi.Data;
using HastaneProjesi.Models;
using Microsoft.AspNetCore.Authorization;

namespace HastaneProjesi.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class RecetegGoruntüleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecetegGoruntüleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecetegGoruntüle
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recete.Include(r => r.Tahliller).ThenInclude(x=>x.hastaGecmisi.HastaSikayeti.HastaKabul.Hastalar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RecetegGoruntüle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recete = await _context.Recete
                .Include(r => r.Tahliller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recete == null)
            {
                return NotFound();
            }

            return View(recete);
        }

        // GET: RecetegGoruntüle/Create
        public IActionResult Create()
        {
            ViewData["TahlillerId"] = new SelectList(_context.Tahliller, "Id", "TahlilAd");
            return View();
        }

        // POST: RecetegGoruntüle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IlacAd,TahlillerId")] Recete recete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TahlillerId"] = new SelectList(_context.Tahliller, "Id", "TahlilAd", recete.TahlillerId);
            return View(recete);
        }

        // GET: RecetegGoruntüle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recete = await _context.Recete.FindAsync(id);
            if (recete == null)
            {
                return NotFound();
            }
            ViewData["TahlillerId"] = new SelectList(_context.Tahliller, "Id", "TahlilAd", recete.TahlillerId);
            return View(recete);
        }

        // POST: RecetegGoruntüle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IlacAd,TahlillerId")] Recete recete)
        {
            if (id != recete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceteExists(recete.Id))
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
            ViewData["TahlillerId"] = new SelectList(_context.Tahliller, "Id", "TahlilAd", recete.TahlillerId);
            return View(recete);
        }

        // GET: RecetegGoruntüle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recete = await _context.Recete
                .Include(r => r.Tahliller)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recete == null)
            {
                return NotFound();
            }

            return View(recete);
        }

        // POST: RecetegGoruntüle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recete = await _context.Recete.FindAsync(id);
            _context.Recete.Remove(recete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceteExists(int id)
        {
            return _context.Recete.Any(e => e.Id == id);
        }
    }
}
