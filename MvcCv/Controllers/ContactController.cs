using Microsoft.AspNetCore.Mvc;
using MvcCv.ViewComponents;
using MvcCv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;
using MvcCv.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace MvcCv.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MvcCvContext _context = new MvcCvContext();
        GenericRepository<Contact> repo = new GenericRepository<Contact>();
        public IActionResult Index()
        {
            var messages = repo.List();
            messages.Reverse();
            return View(messages);
        }
        [HttpGet]
        public IActionResult _ContactComponentPartial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult _ContactComponentPartial(Contact c)
        {
            c.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.Contacts.Add(c);
            _context.SaveChanges();
            return View();
        }
    }
}
