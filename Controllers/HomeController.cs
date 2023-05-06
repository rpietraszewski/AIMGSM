using AIMGSM.Interfaces;
using AIMGSM.Models;
using AIMGSM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AIMGSM.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace AIMGSM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactService _contactService;
        public HomeController(ILogger<HomeController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            ContactVM contact = new ContactVM();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Contact(ContactVM model)
        {

            if (ModelState.IsValid)
            {
                _contactService.SendEmail(model.Name, model.Email, model.Message);
                return Content("Dziękujemy za wiadomość");
            }
            return View();
        }

        public IActionResult Services()
        {
            ServiceVM service = new ServiceVM();
            return View(service);
        }

        public IActionResult Blog()
        {
            return View();
        }
    }
}