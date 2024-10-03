using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ExperienceController : Controller
    {
        ExperienceRepository repo = new ExperienceRepository();
        public IActionResult Index()
        {
            var exp = repo.List();
            return View(exp);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experience p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddExperience");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            Experience t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            Experience t = repo.Find(x =>x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetExperience(Experience p)
        {
            if (!ModelState.IsValid)
            {
                return View("GetExperience");
            }
            Experience t = repo.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.Description = p.Description;
            t.Date = p.Date;
            t.Subdescription = p.Subdescription;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
