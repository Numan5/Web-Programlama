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
    [Authorize(Roles = "Admin")]
    public class ReceteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recete
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recete.Include(r => r.Tahliller).ThenInclude(y=>y.hastaGecmisi.HastaSikayeti.HastaKabul.Hastalar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recete/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recete = await _context.Recete
                .Include(r => r.Tahliller).Include(r=>r.Tahliller.hastaGecmisi.HastaSikayeti.HastaKabul.Hastalar).Include(r=>r.Tahliller.hastaGecmisi.HastaSikayeti.HastaKabul.Doktorlar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recete == null)
            {
                return NotFound();
            }

            return View(recete);
        }

        // GET: Recete/Create
        public IActionResult Create()
        {
            var dondur2 = (from a in _context.Tahliller join b in _context.Hastalar on a.Id equals b.Id select new { Id = a.Id, HastaSikayet = b.Ad }).ToList();

            ViewData["TahlillerId"] = new SelectList(dondur2, "Id", "HastaSikayet");
            return View();
        }

        // POST: Recete/Create
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

        // GET: Recete/Edit/5
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

            var dondur2 = (from a in _context.Tahliller join b in _context.Hastalar on a.Id equals b.Id select new { Id = a.Id, HastaSikayet = b.Ad }).ToList();
            ViewData["TahlillerId"] = new SelectList(dondur2, "Id", "HastaSikayet", recete.TahlillerId);
            return View(recete);
        }

        // POST: Recete/Edit/5
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

        // GET: Recete/Delete/5
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

        // POST: Recete/Delete/5
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
