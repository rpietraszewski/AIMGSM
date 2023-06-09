﻿using AIMGSM.Interfaces;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AIMGSM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IContactService _contactService;
        private readonly IPriceService _priceService;
        private readonly IFormService _formService;
        private readonly IDeviceService _deviceService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(ILogger<HomeController> logger, IContactService contactService, IPriceService priceService, IFormService formService, IWebHostEnvironment hostingEnvironment, IDeviceService deviceService)
        {
            _logger = logger;
            _contactService = contactService;
            _priceService = priceService;
            _formService = formService;
            _hostingEnvironment = hostingEnvironment;
            _deviceService = deviceService;
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
        public async Task<IActionResult> Index(FormVM formVM)
        {
            if (formVM.ImageFile != null && formVM.ImageFile.Length > 0)
            {
                string uniqueFileName = GetUniqueFileName(formVM.ImageFile.FileName);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "assets/img/forms");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formVM.ImageFile.CopyToAsync(fileStream);
                }

                formVM.ImageUrl = $"{uniqueFileName}";
            }
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

        [HttpGet]
        public IActionResult PricesByBrandModel([FromQuery] BrandEnum Brand, string Model)
        {
            List<PriceVM> list = _priceService.GetAllPricesByBrandModel(Brand, Model);
            ViewBag.Brand = Brand;
            ViewBag.Model = Model;
            return View(list);
        }

        [HttpGet]
        public IActionResult DevicesByBrand([FromQuery] BrandEnum Brand)
        {
            List<DeviceVM> list = _deviceService.GetAllDevicesByBrand(Brand);
            ViewBag.Brand = Brand;
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