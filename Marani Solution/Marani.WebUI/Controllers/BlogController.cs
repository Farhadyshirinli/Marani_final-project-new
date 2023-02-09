using Marani.Domain.Business.BlogPostModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marani.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMediator mediator;

        public BlogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index([FromRoute] BlogPostGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        public IActionResult Details(int id)

        {
            return View();
        }
    }
}
