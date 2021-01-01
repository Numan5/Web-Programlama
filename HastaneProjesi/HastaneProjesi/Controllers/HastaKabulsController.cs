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
    public class HastaKabulsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HastaKabulsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HastaKabuls
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HastaKabul.Include(h => h.Doktorlar).Include(h => h.Hastalar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HastaKabuls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastaKabul = await _context.HastaKabul
                .Include(h => h.Doktorlar)
                .Include(h => h.Hastalar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaKabul == null)
            {
                return NotFound();
            }

            return View(hastaKabul);
        }

        // GET: HastaKabuls/Create
        public IActionResult Create()
        {
            ViewData["DoktorlarId"] = new SelectList(_context.Doktorlar, "Id", "Ad");
            ViewData["HastalarId"] = new SelectList(_context.Hastalar, "Id", "Ad");
            return View();
        }

        // POST: HastaKabuls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GelisTarihi,HastalarId,DoktorlarId")] HastaKabul hastaKabul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastaKabul);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoktorlarId"] = new SelectList(_context.Doktorlar, "Id", "Ad", hastaKabul.DoktorlarId);
            ViewData["HastalarId"] = new SelectList(_context.Hastalar, "Id", "Ad", hastaKabul.HastalarId);
            return View(hastaKabul);
        }

        // GET: HastaKabuls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastaKabul = await _context.HastaKabul.FindAsync(id);
            if (hastaKabul == null)
            {
                return NotFound();
            }
            ViewData["DoktorlarId"] = new SelectList(_context.Doktorlar, "Id", "Ad", hastaKabul.DoktorlarId);
            ViewData["HastalarId"] = new SelectList(_context.Hastalar, "Id", "Ad", hastaKabul.HastalarId);
            return View(hastaKabul);
        }

        // POST: HastaKabuls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GelisTarihi,HastalarId,DoktorlarId")] HastaKabul hastaKabul)
        {
            if (id != hastaKabul.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastaKabul);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastaKabulExists(hastaKabul.Id))
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
            ViewData["DoktorlarId"] = new SelectList(_context.Doktorlar, "Id", "Ad", hastaKabul.DoktorlarId);
            ViewData["HastalarId"] = new SelectList(_context.Hastalar, "Id", "Ad", hastaKabul.HastalarId);
            return View(hastaKabul);
        }

        // GET: HastaKabuls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastaKabul = await _context.HastaKabul
                .Include(h => h.Doktorlar)
                .Include(h => h.Hastalar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastaKabul == null)
            {
                return NotFound();
            }

            return View(hastaKabul);
        }

        // POST: HastaKabuls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hastaKabul = await _context.HastaKabul.FindAsync(id);
            _context.HastaKabul.Remove(hastaKabul);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastaKabulExists(int id)
        {
            return _context.HastaKabul.Any(e => e.Id == id);
        }
    }
}
