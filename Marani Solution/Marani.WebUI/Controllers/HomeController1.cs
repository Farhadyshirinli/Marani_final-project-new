using Marani.Domain.AppCode.Extensions;
using Marani.Domain.AppCode.Services;
using Marani.Domain.Models.DataContexts;
using Marani.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Marani.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly MaraniDbContext db;
        private readonly CryptoService cryptoService;
        private readonly EmailService emailService;



        public HomeController(MaraniDbContext db, CryptoService cryptoService, EmailService emailService)
        {
            this.db = db;
            this.cryptoService = cryptoService;
            this.emailService = emailService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactPost model)
        {
            if (ModelState.IsValid)
            {
                db.ContactPosts.Add(model);
                db.SaveChanges();

                var response = new
                {
                    error = false,
                    message = "Please, try again",

                };

                return Json(response);
            }

            var responseError = new
            {
                error = true,
                message = "Thank you. We will back",
                state = ModelState.GetErrors()

            };

            return Json(responseError);

        }


        [HttpPost]
        public IActionResult Faq()
        {
            var data = db.Faqs.Where(f => f.DeletedDate == null).ToList();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(Subscribe model)
        {

            if (!ModelState.IsValid)
            {
                string msg = ModelState.Values.First().Errors[0].ErrorMessage;

                return Json(new
                {
                    error = true,
                    message = msg
                });
            }
            var entity = db.Subscribes.FirstOrDefault(s => s.Email.Equals(model.Email));

            if (entity == null && entity.IsApproved == true)
            {
                return Json(new
                {
                    error = false,
                    message = "You have already subscribed"
                });
            }

            if (entity == null)
            {
                db.Subscribes.Add(model);
                db.SaveChanges();
            }
            else if (entity != null)
            {
                model.Id = entity.Id;
            }

            string token = $"{model.Id}-{model.Email}-{Guid.NewGuid()}";

            token = cryptoService.Encrypt(token, true);


            string message = $"Confirm your subscription via<a href='https://{Request.Host}/approve-subscribe?token={model.Id}'>link</a>";
            // configuration.SendMail("shirinliferhad@gmail.com", message, "Subscribe Approve");

            await emailService.SendEmailAsync(model.Email, "Subscription Approval", message);

            return Json(new
            {
                error = false,
                message = "Confirmation sent to your Email"
            });
        }


        [Route("/approve-subscribe")]
        public IActionResult SubscribeApprove(string token)
        {

            token = cryptoService.Decrypt(token);

            Match match = Regex.Match(token, @"^(?<id>\d+)-(?<email>[^-]+)-(?<randomKey>.*)$");



            if (match.Success)
            {
                int id = Convert.ToInt32(match.Groups["id"].Value);
                string email = match.Groups["email"].Value;
                string randomKey = match.Groups["randomKey"].Value;

                var entity = db.Subscribes.FirstOrDefault(s => s.Id == id && s.DeletedDate == null);

                if (entity == null)
                {
                    ViewBag.Message = Tuple.Create(true, "Token Error");
                    goto end;
                }

                if (entity.IsApproved)
                {
                    ViewBag.Message = Tuple.Create(true, "Your apply confirmed");

                    goto end;
                }

                entity.IsApproved = true;
                entity.ApprovedDate = DateTime.UtcNow.AddHours(4);
                db.SaveChanges();


                ViewBag.Message = Tuple.Create(false, "Your subscription confirmed");

            }
            else
            {
                ViewBag.Message = Tuple.Create(true, "Token Error");
            }

        end:
            return View();


        }
    }
}
