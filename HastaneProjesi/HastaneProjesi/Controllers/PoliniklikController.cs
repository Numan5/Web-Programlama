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
    public class PoliniklikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliniklikController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Poliniklik
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Poliniklik.Include(p => p.Hastaneler);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Poliniklik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poliniklik = await _context.Poliniklik
                .Include(p => p.Hastaneler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poliniklik == null)
            {
                return NotFound();
            }

            return View(poliniklik);
        }

        // GET: Poliniklik/Create
        public IActionResult Create()
        {
            ViewData["HastanelerId"] = new SelectList(_context.Hastaneler, "Id", "Ad");
            return View();
        }

        // POST: Poliniklik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PolinikAd,HastanelerId")] Poliniklik poliniklik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poliniklik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HastanelerId"] = new SelectList(_context.Hastaneler, "Id", "Ad", poliniklik.HastanelerId);
            return View(poliniklik);
        }

        // GET: Poliniklik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poliniklik = await _context.Poliniklik.FindAsync(id);
            if (poliniklik == null)
            {
                return NotFound();
            }
            ViewData["HastanelerId"] = new SelectList(_context.Hastaneler, "Id", "Ad", poliniklik.HastanelerId);
            return View(poliniklik);
        }

        // POST: Poliniklik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PolinikAd,HastanelerId")] Poliniklik poliniklik)
        {
            if (id != poliniklik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poliniklik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliniklikExists(poliniklik.Id))
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
            ViewData["HastanelerId"] = new SelectList(_context.Hastaneler, "Id", "Ad", poliniklik.HastanelerId);
            return View(poliniklik);
        }

        // GET: Poliniklik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poliniklik = await _context.Poliniklik
                .Include(p => p.Hastaneler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poliniklik == null)
            {
                return NotFound();
            }

            return View(poliniklik);
        }

        // POST: Poliniklik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poliniklik = await _context.Poliniklik.FindAsync(id);
            _context.Poliniklik.Remove(poliniklik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliniklikExists(int id)
        {
            return _context.Poliniklik.Any(e => e.Id == id);
        }
    }
}
