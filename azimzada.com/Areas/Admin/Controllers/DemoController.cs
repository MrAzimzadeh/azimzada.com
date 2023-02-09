using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using azimzada.com.Data;
using azimzada.com.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace azimzada.com.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DemoController : Controller
    {
        private readonly ILogger<ExperenciesController> _logger;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public DemoController(ILogger<ExperenciesController> logger, AppDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var demo = _context.Demos.OrderByDescending(x => x.Id).ToList();
            return View(demo);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string description, DateTime startingDate, DateTime endingDate, string url, IFormFile photo)
        {

            Demo demo = new Demo();

            if (photo != null)
            {
                var path = "/uploads/" + Guid.NewGuid() + photo.FileName;
                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                demo.Input = path;
            }
            else
            {
                demo.Input = "";
            }
            demo.Name = name;
            demo.Description = description;
            demo.StartingDate = startingDate;
            demo.EndingDate = endingDate;
            if (demo.Url != null)
            {
                demo.Url = null;
            }
            else
            {
                demo.Url = url;
            }
            _context.Demos.Add(demo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {

            var delete = _context.Demos.FirstOrDefault(x => x.Id == id);
            return View(delete);
        }
        [HttpPost]
        public IActionResult Delete(Demo demo)
        {
            var delet = _context.Demos.FirstOrDefault(x => x.Id == demo.Id);
            _context.Demos.Remove(delet);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int id)
        {
            var detail = _context.Demos.FirstOrDefault(x => x.Id == id);
            return View(detail);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
