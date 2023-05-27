using AIMGSM.Interfaces;
using AIMGSM.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AIMGSM.Models;
using AIMGSM.Repositories;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using AIMGSM.Data;
using System.Diagnostics.Contracts;
using Microsoft.SqlServer.Server;

namespace AIMGSM.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IContactService _contactService;
        private readonly IServiceService _serviceService;
        private readonly IDeviceService _deviceService;
        private readonly IPriceService _priceService;
        private readonly IFormService _formService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminController(ILogger<AdminController> logger, IContactService contactService, IServiceService serviceService, IDeviceService deviceService, IPriceService priceService, IFormService formService, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _contactService = contactService;
            _serviceService = serviceService;
            _deviceService = deviceService;
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
        public IActionResult Services()
        {
            List<ServiceVM> list = _serviceService.GetAllServices();
            return View(list);
        }
        [HttpGet]
        public IActionResult ServiceAdd()
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("Services");
        }
        [HttpPost]
        public IActionResult ServiceAdd(ServiceVM serviceVM)
        {
            if (ModelState.IsValid)
            {
                _serviceService.AddService(serviceVM);
                return RedirectToAction("Services");
            }
            return View(serviceVM);
        }
        [HttpPost]
        public IActionResult ServiceDelete(int id)
        {
            if (id != null)
            {
                _serviceService.RemoveService(id);
                return RedirectToAction("Services");
            }
            return RedirectToAction("Services");
        }
        [HttpGet]
        public IActionResult Devices()
        {
            List<DeviceVM> list = _deviceService.GetAllDevices();
            return View(list);
        }
        [HttpGet]
        public IActionResult DeviceAdd()
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("Devices");
        }
        [HttpPost]
        public async Task<IActionResult> DeviceAdd(DeviceVM deviceVM)
        {
                if (deviceVM.ImageFile != null && deviceVM.ImageFile.Length > 0)
                {
                    string uniqueFileName = GetUniqueFileName(deviceVM.ImageFile.FileName);

                    // Set the file path
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "assets/img/devices");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Save the image file to the server
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await deviceVM.ImageFile.CopyToAsync(fileStream);
                    }

                    // Set the image URL in the ViewModel
                    deviceVM.ImageUrl = $"{uniqueFileName}";
                }
                _deviceService.AddDevice(deviceVM);
                return RedirectToAction("Devices");
        }
        [HttpPost]
        public IActionResult DeviceDelete(int id)
        {
            var device = _deviceService.GetDeviceById(id);
            if (id != null)
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "assets/img/devices", device.ImageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                _deviceService.RemoveDevice(id);
                return RedirectToAction("Devices");
            }
            return RedirectToAction("Devices");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Prices()
        {
            List<PriceVM> list = _priceService.GetAllPrices();
            return View(list);
        }
        [HttpGet]
        public IActionResult PricesByBrand(BrandEnum Brand)
        {
            List<PriceVM> list = _priceService.GetAllPricesByBrand(Brand);
            return View(list);
        }

        [HttpGet]
        public IActionResult PriceAdd()
        {
            var devices = _deviceService.GetAllDevices();
            ViewBag.Devices = devices;
            var services = _serviceService.GetAllServices();
            ViewBag.Services = services;
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("Prices");
        }
        [HttpPost]
        public IActionResult PriceAdd(PriceAddVM priceAddVM)
        {
            if (ModelState.IsValid)
            {
                _priceService.AddPrice(priceAddVM);
            }
            return RedirectToAction("Prices");
        }
        [HttpPost]
        public IActionResult PriceDelete(int id)
        {
            if (ModelState.IsValid)
            {
                _priceService.RemovePrice(id);
            }
            return RedirectToAction("Prices");
        }
        [HttpGet]
        public IActionResult Forms()
        {
            List<FormVM> list = _formService.GetAllForms();
            return View(list);
        }
        [HttpPost]
        public IActionResult FormDelete(int id)
        {
            var form = _formService.GetFormById(id);
            if (ModelState.IsValid)
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "assets/img/forms", form.ImageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                _formService.RemoveForm(id);
            }
            return RedirectToAction("Forms");
        }
    }
}
