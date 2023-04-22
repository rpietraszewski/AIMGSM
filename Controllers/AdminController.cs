using AIMGSM.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AIMGSM.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IContactService _contactService;
        public AdminController(ILogger<AdminController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
