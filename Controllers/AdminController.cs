using AIMGSM.Interfaces;
using AIMGSM.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AIMGSM.Models;
using AIMGSM.Repositories;

namespace AIMGSM.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IContactService _contactService;
        private readonly IServiceService _serviceService;
        private readonly IDeviceService _deviceService;
        public AdminController(ILogger<AdminController> logger, IContactService contactService, IServiceService serviceService, IDeviceService deviceService)
        {
            _logger = logger;
            _contactService = contactService;
            _serviceService = serviceService;
            _deviceService = deviceService;
        }
        public IActionResult Services()
        {
            ViewBag.services = _serviceService.GetAllServices();
            return View();
        }
        public ActionResult ServiceAdd()
        {
            Service service = new Service();

            _serviceService.AddService(service);
            return RedirectToAction("Services");
        }
        public ActionResult Devices()
        {
            List<DeviceVM> list = _deviceService.GetAllDevices();

            return View(list);
        }
        public ActionResult DeviceAdd(DeviceVM deviceVM)
        {
            if (ModelState.IsValid)
            {
                _deviceService.AddDevice(deviceVM);
                return RedirectToAction("Services");
            }
            return View(deviceVM);
        }
        public ActionResult DeviceDelete(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                if (id != null)
                {
                    _deviceService.RemoveDevice((int)id);
                }
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
