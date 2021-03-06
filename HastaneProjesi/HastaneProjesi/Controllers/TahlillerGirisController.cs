﻿using System;
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
    public class TahlillerGirisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TahlillerGirisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TahlillerGiris
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tahliller.Include(t => t.hastaGecmisi).ThenInclude(x=>x.HastaSikayeti.HastaKabul.Hastalar);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TahlillerGiris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tahliller = await _context.Tahliller
                .Include(t => t.hastaGecmisi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tahliller == null)
            {
                return NotFound();
            }

            return View(tahliller);
        }

        // GET: TahlillerGiris/Create
        public IActionResult Create()
        {

            var dondur = (from a in _context.Hastalar join b in _context.HastaGecmisi on a.Id equals b.HastaSikayetiId select new { HastaKabulId = b.Id, Ad = a.Ad }).ToList();


            ViewData["HastaGecmisiId"] = new SelectList(dondur, "HastaKabulId", "Ad");
            return View();
        }

        // POST: TahlillerGiris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TahlilAd,TahlilSonucu,HastaGecmisiId")] Tahliller tahliller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tahliller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HastaGecmisiId"] = new SelectList(_context.HastaGecmisi, "Id", "GecirdigiAmeliyatlar", tahliller.HastaGecmisiId);
            return View(tahliller);
        }

        // GET: TahlillerGiris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tahliller = await _context.Tahliller.FindAsync(id);
            if (tahliller == null)
            {
                return NotFound();
            }
            var dondur = (from a in _context.Hastalar join b in _context.HastaGecmisi on a.Id equals b.HastaSikayetiId select new { HastaKabulId = b.Id, Ad = a.Ad }).ToList();
            ViewData["HastaGecmisiId"] = new SelectList(dondur, "HastaKabulId", "Ad", tahliller.HastaGecmisiId);
            return View(tahliller);
        }

        // POST: TahlillerGiris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TahlilAd,TahlilSonucu,HastaGecmisiId")] Tahliller tahliller)
        {
            if (id != tahliller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tahliller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TahlillerExists(tahliller.Id))
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
            ViewData["HastaGecmisiId"] = new SelectList(_context.HastaGecmisi, "Id", "GecirdigiAmeliyatlar", tahliller.HastaGecmisiId);
            return View(tahliller);
        }

        // GET: TahlillerGiris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tahliller = await _context.Tahliller
                .Include(t => t.hastaGecmisi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tahliller == null)
            {
                return NotFound();
            }

            return View(tahliller);
        }

        // POST: TahlillerGiris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tahliller = await _context.Tahliller.FindAsync(id);
            _context.Tahliller.Remove(tahliller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TahlillerExists(int id)
        {
            return _context.Tahliller.Any(e => e.Id == id);
        }
    }
}
