using AIMGSM.Interfaces;
using AIMGSM.Models;
using AIMGSM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AIMGSM.ViewModels;
using System.ComponentModel.DataAnnotations;
using AIMGSM.Data;

namespace AIMGSM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IContactService _contactService;
        private readonly IPriceService _priceService;
        public HomeController(ILogger<HomeController> logger, IContactService contactService, IPriceService priceService)
        {
            _logger = logger;
            _contactService = contactService;
            _priceService = priceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PricesByBrand([FromQuery] BrandEnum Brand)
        {
            List<PriceVM> list = _priceService.GetAllPricesByBrand(Brand);
            return View(list);
        }
        [HttpGet]
        public IActionResult PricesByType([FromQuery] TypeEnum Type)
        {
            List<PriceVM> list = _priceService.GetAllPricesByType(Type);
            return View(list);
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