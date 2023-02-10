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
    public class AwardController : Controller
    {
        private readonly ILogger<ExperenciesController> _logger;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public AwardController(ILogger<ExperenciesController> logger, AppDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var award = _context.Awards.OrderByDescending(x => x.Id).ToList();
            return View(award);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string description, DateTime dateTime, string url, IFormFile photo)
        {

            Award award = new Award();

            if (photo != null)
            {
                var path = "/uploads/" + Guid.NewGuid() + photo.FileName;
                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                award.PhotoUrl = path;
            }
            else
            {
                award.PhotoUrl = "";
            }
            award.Title = title;
            award.Description = description;
            award.DateTime = dateTime;
            if (award.Url != null)
            {
                award.Url = null;
            }
            else
            {
                award.Url = url;
            }
            _context.Awards.Add(award);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {

            var delete = _context.Awards.FirstOrDefault(x => x.Id == id);
            return View(delete);
        }
        [HttpPost]
        public IActionResult Delete(Award award)
        {
            var delet = _context.Awards.FirstOrDefault(x => x.Id == award.Id);
            _context.Awards.Remove(delet);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int id)
        {
            var detail = _context.Awards.FirstOrDefault(x => x.Id == id);
            return View(detail);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}