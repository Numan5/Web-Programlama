using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneProjesi.Data;
using HastaneProjesi.Models;

namespace HastaneProjesi.Controllers
{
    public class HastaGecmisiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HastaGecmisiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HastaGecmisi
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HastaGecmisi.Include(h => h.HastaSikayeti).ThenInclude(x=>x.HastaKabul.Hastalar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HastaGecmisi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastaGecmisi = await _context.HastaGecmisi
                .Include(h => h.HastaSikayeti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaGecmisi == null)
            {
                return NotFound();
            }

            return View(hastaGecmisi);
        }

        // GET: HastaGecmisi/Create
        public IActionResult Create()
        {
            //var dondur = (from a in _context.Hastalar join b in _context.HastaKabul on a.Id equals b.HastalarId select new { HastaKabulId = b.Id, Ad = a.Ad }).ToList();

            //var dondur2 = _context.HastaGecmisi.Include(x => x.HastaSikayeti).ThenInclude(x => x.HastaKabul.Hastalar).Where(x => x.HastaSikayetiId.Equals(x.HastaSikayeti.Id) && (x.HastaSikayeti.HastaKabulId.Equals(x.HastaSikayeti.HastaKabul.Id) && (x.HastaSikayeti.HastaKabul.HastalarId.Equals(x.HastaSikayeti.HastaKabul.Hastalar.Id)))).Select(x=>new {A=x.Id,B=x.HastaSikayeti.HastaKabul.Hastalar.Ad}).ToList();

            var dondur2 = (from a in _context.HastaSikayeti join b in _context.Hastalar on a.HastaKabulId equals b.Id select new { Id = a.Id, HastaSikayet = b.Ad }).ToList();

            ViewData["HastaSikayetiId"] = new SelectList(dondur2, "Id", "HastaSikayet");
            return View();
        }

        // POST: HastaGecmisi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GecirdigiHastaliklar,GecirdigiAmeliyatlar,Tarih,HastaSikayetiId")] HastaGecmisi hastaGecmisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastaGecmisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["HastaSikayetiId"] = new SelectList(_context.HastaSikayeti, "Id", "HastaSikayet", hastaGecmisi.HastaSikayetiId);
            return View(hastaGecmisi);
        }

        // GET: HastaGecmisi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastaGecmisi = await _context.HastaGecmisi.FindAsync(id);
            if (hastaGecmisi == null)
            {
                return NotFound();
            }
            var dondur2 = (from a in _context.HastaSikayeti join b in _context.Hastalar on a.HastaKabulId equals b.Id select new { Id = a.Id, HastaSikayet = b.Ad }).ToList();
            ViewData["HastaSikayetiId"] = new SelectList(dondur2, "Id", "HastaSikayet", hastaGecmisi.HastaSikayetiId);
            return View(hastaGecmisi);
        }

        // POST: HastaGecmisi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GecirdigiHastaliklar,GecirdigiAmeliyatlar,Tarih,HastaSikayetiId")] HastaGecmisi hastaGecmisi)
        {
            if (id != hastaGecmisi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastaGecmisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaGecmisiExists(hastaGecmisi.Id))
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
            ViewData["HastaSikayetiId"] = new SelectList(_context.HastaSikayeti, "Id", "HastaSikayet", hastaGecmisi.HastaSikayetiId);
            return View(hastaGecmisi);
        }

        // GET: HastaGecmisi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastaGecmisi = await _context.HastaGecmisi
                .Include(h => h.HastaSikayeti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaGecmisi == null)
            {
                return NotFound();
            }

            return View(hastaGecmisi);
        }

        // POST: HastaGecmisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hastaGecmisi = await _context.HastaGecmisi.FindAsync(id);
            _context.HastaGecmisi.Remove(hastaGecmisi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaGecmisiExists(int id)
        {
            return _context.HastaGecmisi.Any(e => e.Id == id);
        }
    }
}
