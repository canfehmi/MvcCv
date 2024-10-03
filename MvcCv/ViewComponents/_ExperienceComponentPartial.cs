using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents
{
    public class _ExperienceComponentPartial : ViewComponent
    {
        MvcCvContext _context = new MvcCvContext();
        public IViewComponentResult Invoke()
        {
            var exp = _context.Experiences.ToList();
            return View(exp);
        }
    }
}
