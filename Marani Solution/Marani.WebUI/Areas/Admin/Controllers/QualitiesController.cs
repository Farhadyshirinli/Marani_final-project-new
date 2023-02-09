using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marani.Domain.Models.DataContexts;
using Marani.Domain.Models.Entities;

namespace Marani.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QualitiesController : Controller
    {
        private readonly MaraniDbContext db;

        public QualitiesController(MaraniDbContext db)
        {
            this.db = db;
        }

        // GET: Admin/Qualities
        public async Task<IActionResult> Index()
        {
            return View(await db.ProductQuality.ToListAsync());
        }

        // GET: Admin/Qualities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productQuality = await db.ProductQuality
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productQuality == null)
            {
                return NotFound();
            }

            return View(productQuality);
        }

        // GET: Admin/Qualities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Qualities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,CreatedDate,DeletedDate")] ProductQuality productQuality)
        {
            if (ModelState.IsValid)
            {
                db.Add(productQuality);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productQuality);
        }

        // GET: Admin/Qualities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productQuality = await db.ProductQuality.FindAsync(id);
            if (productQuality == null)
            {
                return NotFound();
            }
            return View(productQuality);
        }

        // POST: Admin/Qualities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedDate,DeletedDate")] ProductQuality productQuality)
        {
            if (id != productQuality.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productQuality);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductQualityExists(productQuality.Id))
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
            return View(productQuality);
        }

        // GET: Admin/Qualities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productQuality = await db.ProductQuality
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productQuality == null)
            {
                return NotFound();
            }

            return View(productQuality);
        }

        // POST: Admin/Qualities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productQuality = await db.ProductQuality.FindAsync(id);
            db.ProductQuality.Remove(productQuality);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductQualityExists(int id)
        {
            return db.ProductQuality.Any(e => e.Id == id);
        }
    }
}
