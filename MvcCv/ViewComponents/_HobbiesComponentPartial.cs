using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents
{
    public class _HobbiesComponentPartial : ViewComponent
    {
        MvcCvContext _context = new MvcCvContext();
        public IViewComponentResult Invoke()
        {
            var hobbies = _context.Hobbies.ToList();
            return View(hobbies);
        }
    }
}
