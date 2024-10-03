using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        GenericRepository<Skill> repo = new GenericRepository<Skill>();
        public IActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public IActionResult NewSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewSkill(Skill skill)
        {
            if(!ModelState.IsValid)
            {
                return View("NewSkill");
            }
            repo.TAdd(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetSkill(int id)
        {
            Skill t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public IActionResult GetSkill(Skill p)
        {
            if (!ModelState.IsValid)
            {
                return View("GetSkill");
            }
            Skill t = repo.Find(x =>x.ID == p.ID);
            t.SkillName = p.SkillName;
            t.Progress = p.Progress;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            Skill t = repo.Find(x =>x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
    }
}
