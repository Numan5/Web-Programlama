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
    [Authorize(Roles ="Admin")]
    public class DoktorlarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoktorlarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doktorlar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Doktorlar.Include(d => d.Poliniklik).Include(d => d.Unvanlar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Doktorlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktorlar = await _context.Doktorlar
                .Include(d => d.Poliniklik)
                .Include(d => d.Unvanlar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doktorlar == null)
            {
                return NotFound();
            }

            return View(doktorlar);
        }

        // GET: Doktorlar/Create
        public IActionResult Create()
        {
            ViewData["PoliniklikId"] = new SelectList(_context.Poliniklik, "Id", "PolinikAd");
            ViewData["UnvanlarId"] = new SelectList(_context.Unvanlar, "Id", "UnvanAd");
            return View();
        }

        // POST: Doktorlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,DogumYeri,Cinsiyet,DogumTarihi,UnvanlarId,PoliniklikId")] Doktorlar doktorlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doktorlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoliniklikId"] = new SelectList(_context.Poliniklik, "Id", "PolinikAd", doktorlar.PoliniklikId);
            ViewData["UnvanlarId"] = new SelectList(_context.Unvanlar, "Id", "UnvanAd", doktorlar.UnvanlarId);
            return View(doktorlar);
        }

        // GET: Doktorlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktorlar = await _context.Doktorlar.FindAsync(id);
            if (doktorlar == null)
            {
                return NotFound();
            }
            ViewData["PoliniklikId"] = new SelectList(_context.Poliniklik, "Id", "PolinikAd", doktorlar.PoliniklikId);
            ViewData["UnvanlarId"] = new SelectList(_context.Unvanlar, "Id", "UnvanAd", doktorlar.UnvanlarId);
            return View(doktorlar);
        }

        // POST: Doktorlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,DogumYeri,Cinsiyet,DogumTarihi,UnvanlarId,PoliniklikId")] Doktorlar doktorlar)
        {
            if (id != doktorlar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktorlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorlarExists(doktorlar.Id))
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
            ViewData["PoliniklikId"] = new SelectList(_context.Poliniklik, "Id", "PolinikAd", doktorlar.PoliniklikId);
            ViewData["UnvanlarId"] = new SelectList(_context.Unvanlar, "Id", "UnvanAd", doktorlar.UnvanlarId);
            return View(doktorlar);
        }

        // GET: Doktorlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktorlar = await _context.Doktorlar
                .Include(d => d.Poliniklik)
                .Include(d => d.Unvanlar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doktorlar == null)
            {
                return NotFound();
            }

            return View(doktorlar);
        }

        // POST: Doktorlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doktorlar = await _context.Doktorlar.FindAsync(id);
            _context.Doktorlar.Remove(doktorlar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorlarExists(int id)
        {
            return _context.Doktorlar.Any(e => e.Id == id);
        }

      
    }
}
