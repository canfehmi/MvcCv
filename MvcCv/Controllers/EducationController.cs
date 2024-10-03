using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<Education> repo = new GenericRepository<Education>();
        public IActionResult Index()
        {
            var educations = repo.List();
            return View(educations);
        }
        [HttpGet]
        public IActionResult NewEducation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewEducation(Education p)
        {
            if (!ModelState.IsValid)
            {
                return View("NewEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var edu = repo.Find(x => x.ID == id);
            repo.TRemove(edu);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetEducation(int id)
        {
            var edu = repo.Find(x => x.ID == id);
            return View(edu);
        }
        [HttpPost]
        public ActionResult GetEducation(Education p)
        {
            if(!ModelState.IsValid)
            {
                return View("GetEducation");
            }
            var edu = repo.Find(x =>x.ID == p.ID);
            edu.Title = p.Title;
            edu.Subdescription1 = p.Subdescription1;
            edu.Subdescription2 = p.Subdescription2;
            edu.Date = p.Date;
            edu.GNO = p.GNO;
            repo.TUpdate(edu);
            return RedirectToAction("Index");
        }
    }
}
