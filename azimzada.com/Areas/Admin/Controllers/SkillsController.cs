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
    public class SkillsController : Controller
    {
        private readonly ILogger<ExperenciesController> _logger;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SkillsController(ILogger<ExperenciesController> logger, AppDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var skillis = _context.Skillis.OrderByDescending(x => x.Id).ToList();
            return View(skillis);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string description, DateTime dateTime, string url, IFormFile photo)
        {

            Skillis skillis = new Skillis();

            if (photo != null)
            {
                var path = "/uploads/" + Guid.NewGuid() + photo.FileName;
                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                skillis.PhotoUrl = path;
            }
            else
            {
                skillis.PhotoUrl = "";
            }
            skillis.Title = title;
            skillis.Description = description;
            skillis.DateTime = dateTime;
            if (skillis.Url != null)
            {
                skillis.Url = null;
            }
            else
            {
                skillis.Url = url;
            }
            _context.Skillis.Add(skillis);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {

            var delete = _context.Skillis.FirstOrDefault(x => x.Id == id);
            return View(delete);
        }
        [HttpPost]
        public IActionResult Delete(Skillis skillis)
        {
            var delet = _context.Skillis.FirstOrDefault(x => x.Id == skillis.Id);
            _context.Skillis.Remove(delet);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int id)
        {
            var detail = _context.Skillis.FirstOrDefault(x => x.Id == id);
            return View(detail);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}