using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertificateController : Controller
    {
        GenericRepository<Sertificate> repo = new GenericRepository<Sertificate>();
        public IActionResult Index()
        {
            var certs = repo.List();
            return View(certs);
        }
        [HttpGet]
        public IActionResult GetSertificate(int id)
        {
            var s = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(s);
        }
        [HttpPost]
        public IActionResult GetSertificate(Sertificate p)
        {
            if (!ModelState.IsValid)
            {
                return View("GetSertificate");
            }
            var cert = repo.Find(x =>x.ID == p.ID);
            cert.Description = p.Description;
            cert.Date = p.Date;
            repo.TUpdate(cert);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult NewSertificate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewSertificate(Sertificate s)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSertificate(int id)
        {
            var del = repo.Find(x =>x.ID == id);
            repo.TRemove(del);
            return RedirectToAction("Index");
        }
    }
}
