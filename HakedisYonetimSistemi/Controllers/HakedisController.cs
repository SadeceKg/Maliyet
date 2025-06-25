using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HakedisYonetimSistemi.Data;
using HakedisYonetimSistemi.Models;
using Microsoft.AspNetCore.Authorization;

namespace HakedisYonetimSistemi.Controllers
{
    [Authorize]
    public class HakedisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HakedisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hakedis
        public async Task<IActionResult> Index()
        {
            var hakedisler = await _context.Hakedisler
                .Include(h => h.Proje)
                .Include(h => h.HakedisDetaylari)
                .ThenInclude(hd => hd.MaliyetKalemi)
                .ToListAsync();
            return View(hakedisler);
        }

        // GET: Hakedis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakedis = await _context.Hakedisler
                .Include(h => h.Proje)
                .Include(h => h.HakedisDetaylari)
                .ThenInclude(hd => hd.MaliyetKalemi)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (hakedis == null)
            {
                return NotFound();
            }

            return View(hakedis);
        }

        // GET: Hakedis/Create
        public IActionResult Create(int? projeId)
        {
            ViewData["ProjeId"] = new SelectList(_context.Projeler.Where(p => p.Durum == ProjeDurum.Aktif), "Id", "ProjeAdi", projeId);
            
            var hakedis = new Hakedis();
            if (projeId.HasValue)
            {
                hakedis.ProjeId = projeId.Value;
            }
            
            return View(hakedis);
        }

        // POST: Hakedis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjeId,HakedisNo,HakedisTarihi,DonemBaslangic,DonemBitis,HakedisTutari,KdvOrani,Aciklama,Durum")] Hakedis hakedis)
        {
            if (ModelState.IsValid)
            {
                hakedis.OlusturulmaTarihi = DateTime.Now;
                _context.Add(hakedis);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Hakediş başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Details), new { id = hakedis.Id });
            }
            ViewData["ProjeId"] = new SelectList(_context.Projeler.Where(p => p.Durum == ProjeDurum.Aktif), "Id", "ProjeAdi", hakedis.ProjeId);
            return View(hakedis);
        }

        // GET: Hakedis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakedis = await _context.Hakedisler.FindAsync(id);
            if (hakedis == null)
            {
                return NotFound();
            }
            ViewData["ProjeId"] = new SelectList(_context.Projeler, "Id", "ProjeAdi", hakedis.ProjeId);
            return View(hakedis);
        }

        // POST: Hakedis/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjeId,HakedisNo,HakedisTarihi,DonemBaslangic,DonemBitis,HakedisTutari,KdvOrani,Aciklama,Durum,OnayTarihi,OdemeTarihi,OlusturulmaTarihi")] Hakedis hakedis)
        {
            if (id != hakedis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hakedis);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Hakediş başarıyla güncellendi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HakedisExists(hakedis.Id))
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
            ViewData["ProjeId"] = new SelectList(_context.Projeler, "Id", "ProjeAdi", hakedis.ProjeId);
            return View(hakedis);
        }

        // GET: Hakedis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakedis = await _context.Hakedisler
                .Include(h => h.Proje)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hakedis == null)
            {
                return NotFound();
            }

            return View(hakedis);
        }

        // POST: Hakedis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hakedis = await _context.Hakedisler.FindAsync(id);
            if (hakedis != null)
            {
                _context.Hakedisler.Remove(hakedis);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Hakediş başarıyla silindi.";
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Hakedis/Onayla/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Onayla(int id)
        {
            var hakedis = await _context.Hakedisler.FindAsync(id);
            if (hakedis != null && hakedis.Durum == HakedisDurum.Onayda)
            {
                hakedis.Durum = HakedisDurum.Onaylandi;
                hakedis.OnayTarihi = DateTime.Now;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Hakediş başarıyla onaylandı.";
            }
            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: Hakedis/Reddet/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reddet(int id)
        {
            var hakedis = await _context.Hakedisler.FindAsync(id);
            if (hakedis != null && hakedis.Durum == HakedisDurum.Onayda)
            {
                hakedis.Durum = HakedisDurum.Reddedildi;
                await _context.SaveChangesAsync();
                TempData["Warning"] = "Hakediş reddedildi.";
            }
            return RedirectToAction(nameof(Details), new { id });
        }

        private bool HakedisExists(int id)
        {
            return _context.Hakedisler.Any(e => e.Id == id);
        }
    }
}