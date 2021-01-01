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
    public class HastalarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HastalarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hastalar
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Hastalar.Include(h => h.KanGrubu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hastalar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastalar = await _context.Ilaclar
                     .Include(i => i.Recete).ThenInclude(p => p.Tahliller.hastaGecmisi.HastaSikayeti.HastaKabul.Doktorlar)                     .FirstOrDefaultAsync(m => m.Id == id);
            //if (hastalar == null)
            //{
            //    return NotFound();
            //}


            return View(hastalar);
        }

        // GET: Hastalar/Create
        public IActionResult Create()
        {
            ViewData["KanGrubuId"] = new SelectList(_context.KanGrubu, "Id", "KanGrubuAd");
            return View();
        }

        // POST: Hastalar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,DogumTarihi,MedeniHali,DogumYeri,Meslek,KanGrubuId,Cinsiyet")] Hastalar hastalar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hastalar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KanGrubuId"] = new SelectList(_context.KanGrubu, "Id", "KanGrubuAd", hastalar.KanGrubuId);
            return View(hastalar);
        }

        // GET: Hastalar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastalar = await _context.Hastalar.FindAsync(id);
            if (hastalar == null)
            {
                return NotFound();
            }
            ViewData["KanGrubuId"] = new SelectList(_context.KanGrubu, "Id", "KanGrubuAd", hastalar.KanGrubuId);
            return View(hastalar);
        }

        // POST: Hastalar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,DogumTarihi,MedeniHali,DogumYeri,Meslek,KanGrubuId,Cinsiyet")] Hastalar hastalar)
        {
            if (id != hastalar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hastalar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HastalarExists(hastalar.Id))
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
            ViewData["KanGrubuId"] = new SelectList(_context.KanGrubu, "Id", "KanGrubuAd", hastalar.KanGrubuId);
            return View(hastalar);
        }

        // GET: Hastalar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hastalar = await _context.Hastalar
                .Include(h => h.KanGrubu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hastalar == null)
            {
                return NotFound();
            }

            return View(hastalar);
        }

        // POST: Hastalar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hastalar = await _context.Hastalar.FindAsync(id);
            _context.Hastalar.Remove(hastalar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HastalarExists(int id)
        {
            return _context.Hastalar.Any(e => e.Id == id);
        }
    }
}
