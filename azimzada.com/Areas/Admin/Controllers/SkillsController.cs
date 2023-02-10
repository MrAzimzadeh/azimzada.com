
using azimzada.com.Data;
using azimzada.com.Models;
using Microsoft.AspNetCore.Mvc;

namespace azimzada.com.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillsController : Controller
    {

        private readonly AppDbContext _context;

        public SkillsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var skill = _context.Skills.OrderByDescending(x => x.Id).ToList();
            return View(skill);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string description, string empty)
        {
            Skill skil = new Skill();
            skil.Title = title;
            skil.Description = description;
            if (empty != null)
            {

                skil.Empty = empty;
            }else
            {
                skil.Empty = "";
            }
            _context.Skills.Add(skil);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        // public IActionResult Delete(int id)
        // {

        //     var delete = _context.Awards.FirstOrDefault(x => x.Id == id);
        //     return View(delete);
        // }
        // [HttpPost]
        // public IActionResult Delete(Award award)
        // {
        //     var delet = _context.Awards.FirstOrDefault(x => x.Id == award.Id);
        //     _context.Awards.Remove(delet);
        //     _context.SaveChanges();
        //     return RedirectToAction(nameof(Index));
        // }
        // public IActionResult Detail(int id)
        // {
        //     var detail = _context.Awards.FirstOrDefault(x => x.Id == id);
        //     return View(detail);
        // }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}