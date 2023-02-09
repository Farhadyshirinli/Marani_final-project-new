using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Marani.Domain.Business.BrandModule;
using Marani.Domain.Models.DataContexts;

namespace Marani.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly MaraniDbContext db;
        private readonly IMediator mediator;

        public BrandsController(MaraniDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        [Authorize(Policy = "admin.brands.index")]
        public async Task<IActionResult> Index(BrandGetAllQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [Authorize(Policy = "admin.brands.details")]
        public async Task<IActionResult> Details(BrandSingleQuery query)
        {
            var response = await mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [Authorize(Policy = "admin.brands.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.brands.create")]
        public async Task<IActionResult> Create(BrandCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                if (response == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        [Authorize(Policy = "admin.brands.edit")]
        public async Task<IActionResult> Edit(int? id, BrandEditCommand command)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await db.Brands
                .FirstOrDefaultAsync(c => c.Id == id);


            if (entity == null)
            {
                return NotFound();
            }


            command.Id = entity.Id;
            command.Name = entity.Name;

            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.brands.edit")]
        public async Task<IActionResult> Edit(BrandEditCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                if (response == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(command);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.brands.remove")]
        public async Task<IActionResult> DeleteConfirmed(BrandRemoveCommand command)
        {
            var response = await mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return db.Brands.Any(e => e.Id == id);
        }
    }
}
