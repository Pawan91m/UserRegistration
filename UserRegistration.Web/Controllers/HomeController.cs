using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using UserRegistration.Web.Models;
using UserRegistration.Web.Data;

namespace UserRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRegistrationRepository _registrationRepository;

        public HomeController(ILogger<HomeController> logger, IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(UserModel user)
        {
            var isRegistered = _registrationRepository.Register(user);
            _logger.LogInformation($"Register action is called for userId {user.UserID}");
            if(isRegistered)
            {
                return View();
            }
            else
            {
                _logger.LogError("There is an error registering the user");
                return View("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
