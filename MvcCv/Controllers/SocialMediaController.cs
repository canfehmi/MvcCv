using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SocialMediaController : Controller
    {
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();
        public IActionResult Index()
        {
            var socials = repo.List();
            return View(socials);
        }
        [HttpGet]
        public IActionResult NewSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewSocialMedia(SocialMedia sm)
        {
            repo.TAdd(sm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var sm = repo.Find(x=>x.Id == id);
            return View(sm);
        }
        [HttpPost]
        public IActionResult Update(SocialMedia social)
        {
            var sm = repo.Find(x=> x.Id == social.Id);
            sm.SocialMediaName = social.SocialMediaName;
            sm.SocialMediaUrl = social.SocialMediaUrl;
            sm.Icon = social.Icon;
            sm.IsActive=true;
            repo.TUpdate(sm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var sm = repo.Find(x=>x.Id==id);
            sm.IsActive = false;
            repo.TUpdate(sm);
            return RedirectToAction("Index");
        }
    }
}
