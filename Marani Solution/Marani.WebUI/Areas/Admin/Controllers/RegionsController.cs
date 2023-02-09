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
    public class RegionsController : Controller
    {
        private readonly MaraniDbContext _context;

        public RegionsController(MaraniDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Regions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductRegions.ToListAsync());
        }

        // GET: Admin/Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRegion = await _context.ProductRegions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productRegion == null)
            {
                return NotFound();
            }

            return View(productRegion);
        }

        // GET: Admin/Regions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Regions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SmallName,Id,CreatedDate,DeletedDate")] ProductRegion productRegion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productRegion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productRegion);
        }

        // GET: Admin/Regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRegion = await _context.ProductRegions.FindAsync(id);
            if (productRegion == null)
            {
                return NotFound();
            }
            return View(productRegion);
        }

        // POST: Admin/Regions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,SmallName,Id,CreatedDate,DeletedDate")] ProductRegion productRegion)
        {
            if (id != productRegion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productRegion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductRegionExists(productRegion.Id))
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
            return View(productRegion);
        }

        // GET: Admin/Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRegion = await _context.ProductRegions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productRegion == null)
            {
                return NotFound();
            }

            return View(productRegion);
        }

        // POST: Admin/Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productRegion = await _context.ProductRegions.FindAsync(id);
            _context.ProductRegions.Remove(productRegion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductRegionExists(int id)
        {
            return _context.ProductRegions.Any(e => e.Id == id);
        }
    }
}
