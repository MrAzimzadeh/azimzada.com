using azimzada.com.Data;
using azimzada.com.Models;
using Microsoft.AspNetCore.Mvc;

namespace azimzada.com.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperenciesController : Controller
    {
        private readonly ILogger<ExperenciesController> _logger;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ExperenciesController(ILogger<ExperenciesController> logger, AppDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var workExpre = _context.Works.OrderByDescending(x => x.Id).ToList();
            return View(workExpre);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, string description, DateTime startingDate, DateTime endingDate, string url, IFormFile photo)
        {

            Work work = new Work();

            if (photo != null)
            {
                var path = "/uploads/" + Guid.NewGuid() + photo.FileName;
                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }
                work.Input = path;
            }
            else
            {
                work.Input = "";
            }
            work.Name = name;
            work.Description = description;
            work.StartingDate = startingDate;
            work.EndingDate = endingDate;
            if (work.Url != null)
            {
                work.Url = null;
            }
            else
            {
                work.Url = url;
            }
            _context.Works.Add(work);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {

            var delete = _context.Works.FirstOrDefault(x => x.Id == id);
            return View(delete);
        }
        [HttpPost]
        public IActionResult Delete(Work work)
        {
            var delet = _context.Works.FirstOrDefault(x => x.Id == work.Id);
            _context.Works.Remove(delet);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detail(int id)
        {
            var detail = _context.Works.FirstOrDefault(x => x.Id == id);
            return View(detail);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}