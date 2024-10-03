using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents
{
    public class _SocialMediaComponentPartial : ViewComponent
    {
        MvcCvContext _context = new MvcCvContext();
        public IViewComponentResult Invoke()
        {
            var values = _context.SocialMedias.Where(x=>x.IsActive==true).ToList();
            return View(values);
        }
    }
}
