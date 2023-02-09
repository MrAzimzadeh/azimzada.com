using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace azimzada.com.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperenciesController : Controller
    {
        private readonly ILogger<ExperenciesController> _logger;

        public ExperenciesController(ILogger<ExperenciesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}