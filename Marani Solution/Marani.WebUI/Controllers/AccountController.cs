using Marani.Domain.Models.Entities.Membership;
using Marani.Domain.Models.FormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marani.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<MaraniUser> signInManager;

        public AccountController(SignInManager<MaraniUser> signInManager, UserManager<MaraniUser> userManager)
        {
            this.signInManager = signInManager;
            UserManager = userManager;
        }

        public UserManager<MaraniUser> UserManager { get; }
        
        [AllowAnonymous]
        [Route("/signin.html")]
        public IActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("/signin.html")]


        public async Task<IActionResult> Signin(UserFormModel model)
        {
            if (!model.IsValid())
                goto end;
            var user = await UserManager.FindByEmailAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("Username", "Username or password is wrong");
                goto end;
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, true, true);


       
            if (result.IsNotAllowed)
            {
                ModelState.AddModelError("Username", "Signin prohibited");
                goto end;
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("Username", "Try in 5 minutes");
                goto end;
            }

            var redirectUrl= Request.Query["ReturnUrl"];

            if (!string.IsNullOrWhiteSpace(redirectUrl))
            {
                return Redirect(redirectUrl);
            }

                return RedirectToAction("Index", "Home");
        end:
            return View(model);
        }
    }
}
