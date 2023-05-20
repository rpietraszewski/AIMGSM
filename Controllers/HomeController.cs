using AIMGSM.Interfaces;
using AIMGSM.Models;
using AIMGSM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AIMGSM.ViewModels;
using System.ComponentModel.DataAnnotations;
using AIMGSM.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HostFiltering;

namespace AIMGSM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IContactService _contactService;
        private readonly IPriceService _priceService;
        private readonly IFormService _formService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(ILogger<HomeController> logger, IContactService contactService, IPriceService priceService, IFormService formService, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _contactService = contactService;
            _priceService = priceService;
            _formService = formService;
            _hostingEnvironment = hostingEnvironment;
        }

        private string GetUniqueFileName(string fileName)
        {
            string uniqueFileName = $"{Guid.NewGuid().ToString()}_{fileName}";
            return uniqueFileName;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(FormVM formVM/*, IFormFile file*/)
        {
            /*
            // Generate a unique file name
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(formVM.ImageUrl)}";

            // Set the path where the image will be saved
            string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "~/wwwroot/assets/img/photos", fileName);

            // Save the image to the specified path
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                formVM.ImageUrl = fileName;
                formVM.ImageUrl.CopyTo(fileStream);
            }*/

            _formService.AddForm(formVM);
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

        public IActionResult ServicesPhoneBrand()
        {
            return View();
        }
    }
}