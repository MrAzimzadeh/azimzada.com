using azimzada.com.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using azimzada.com.Data;
using azimzada.com.VievModels;

namespace azimzada.com.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var works = _context.Works.OrderByDescending(x => x.Id).ToList();
            var demos = _context.Demos.OrderByDescending(x => x.EndingDate).ToList();
            var awards = _context.Awards.OrderByDescending(x=>x.DateTime).ToList();
            HomeVM homeVm = new HomeVM()
            {
                Works = works,
                Demos = demos,
                awards = awards
            };
            return View(homeVm);
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
    }
}