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
    public class IlaclarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IlaclarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ilaclar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ilaclar.Include(i => i.Recete).ThenInclude(i=>i.Tahliller.hastaGecmisi.HastaSikayeti.HastaKabul.Hastalar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ilaclar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilaclar = await _context.Ilaclar
                .Include(i => i.Recete)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilaclar == null)
            {
                return NotFound();
            }

            return View(ilaclar);
        }

        // GET: Ilaclar/Create
        public IActionResult Create()
        {
            ViewData["ReceteId"] = new SelectList(_context.Recete, "Id", "IlacAd");
            return View();
        }

        // POST: Ilaclar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fiyat,Adet,ReceteId")] Ilaclar ilaclar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilaclar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReceteId"] = new SelectList(_context.Recete, "Id", "IlacAd", ilaclar.ReceteId);
            return View(ilaclar);
        }

        // GET: Ilaclar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilaclar = await _context.Ilaclar.FindAsync(id);
            if (ilaclar == null)
            {
                return NotFound();
            }
            ViewData["ReceteId"] = new SelectList(_context.Recete, "Id", "IlacAd", ilaclar.ReceteId);
            return View(ilaclar);
        }

        // POST: Ilaclar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fiyat,Adet,ReceteId")] Ilaclar ilaclar)
        {
            if (id != ilaclar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilaclar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IlaclarExists(ilaclar.Id))
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
            ViewData["ReceteId"] = new SelectList(_context.Recete, "Id", "IlacAd", ilaclar.ReceteId);
            return View(ilaclar);
        }

        // GET: Ilaclar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilaclar = await _context.Ilaclar
                .Include(i => i.Recete)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ilaclar == null)
            {
                return NotFound();
            }

            return View(ilaclar);
        }

        // POST: Ilaclar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ilaclar = await _context.Ilaclar.FindAsync(id);
            _context.Ilaclar.Remove(ilaclar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IlaclarExists(int id)
        {
            return _context.Ilaclar.Any(e => e.Id == id);
        }
    }
}
