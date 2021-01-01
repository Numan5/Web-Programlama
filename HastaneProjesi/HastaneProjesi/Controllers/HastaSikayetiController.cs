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
    public class HastaSikayetiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HastaSikayetiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HastaSikayeti
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HastaSikayeti.Include(h => h.HastaKabul).ThenInclude(h=>h.Hastalar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HastaSikayeti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastaSikayeti = await _context.HastaSikayeti
                .Include(h => h.HastaKabul)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaSikayeti == null)
            {
                return NotFound();
            }

            return View(hastaSikayeti);
        }

        // GET: HastaSikayeti/Create
        public IActionResult Create()
        {
            var dondur = (from a in _context.Hastalar join b in _context.HastaKabul on a.Id equals b.HastalarId select new { HastaKabulId = b.Id, Ad = a.Ad }).ToList();
            ViewData["HastaKabulId"] = new SelectList(dondur, "HastaKabulId", "Ad");
            return View();
        }

        // POST: HastaSikayeti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HastaSikayet,HastaKabulId")] HastaSikayeti hastaSikayeti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastaSikayeti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HastaKabulId"] = new SelectList(_context.HastaKabul, "Id", "Id", hastaSikayeti.HastaKabulId);
            return View(hastaSikayeti);
        }

        // GET: HastaSikayeti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastaSikayeti = await _context.HastaSikayeti.FindAsync(id);
            if (hastaSikayeti == null)
            {
                return NotFound();
            }
            var dondur = (from a in _context.Hastalar join b in _context.HastaKabul on a.Id equals b.HastalarId select new { HastaKabulId = b.Id, Ad = a.Ad }).ToList();
            ViewData["HastaKabulId"] = new SelectList(dondur, "HastaKabulId", "Ad", hastaSikayeti.HastaKabulId);
            return View(hastaSikayeti);
        }

        // POST: HastaSikayeti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HastaSikayet,HastaKabulId")] HastaSikayeti hastaSikayeti)
        {
            if (id != hastaSikayeti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastaSikayeti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaSikayetiExists(hastaSikayeti.Id))
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
            ViewData["HastaKabulId"] = new SelectList(_context.HastaKabul, "Id", "Id", hastaSikayeti.HastaKabulId);
            return View(hastaSikayeti);
        }

        // GET: HastaSikayeti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastaSikayeti = await _context.HastaSikayeti
                .Include(h => h.HastaKabul)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaSikayeti == null)
            {
                return NotFound();
            }

            return View(hastaSikayeti);
        }

        // POST: HastaSikayeti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hastaSikayeti = await _context.HastaSikayeti.FindAsync(id);
            _context.HastaSikayeti.Remove(hastaSikayeti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaSikayetiExists(int id)
        {
            return _context.HastaSikayeti.Any(e => e.Id == id);
        }
    }
}
