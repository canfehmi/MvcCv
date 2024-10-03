using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;
using MvcCv.DAL.Entities;



namespace MvcCv.Controllers
{
    
    public class DefaultController : Controller
    {
        MvcCvContext _context = new MvcCvContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact c)
        {
            if (ModelState.IsValid)
            {
                c.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                _context.Contacts.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
