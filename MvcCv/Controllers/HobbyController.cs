using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize(Roles = "Admin")]
	public class HobbyController : Controller
    {
        GenericRepository<Hobby> repo = new GenericRepository<Hobby>();
        [HttpGet]
        public IActionResult Index()
        {
            var hobby = repo.List();
            return View(hobby);
        }
        [HttpPost]
        public IActionResult Index(Hobby p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Description1 = p.Description1;
            t.Description2 = p.Description2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
