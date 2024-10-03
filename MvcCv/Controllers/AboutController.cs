using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        MvcCvContext db = new MvcCvContext();
        GenericRepository<About> repo = new GenericRepository<About>();
        [HttpGet]
        public IActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }
        [HttpPost]
        public IActionResult Index(About a)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Name = a.Name;
            t.Surname = a.Surname;
            t.Adress = a.Adress;
            t.Telephone = a.Telephone;
            t.Mail = a.Mail;
            t.Description = a.Description;
            t.Image = a.Image;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
