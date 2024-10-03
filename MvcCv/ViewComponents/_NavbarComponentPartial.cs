using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        MvcCvContext context = new MvcCvContext();
        public IViewComponentResult Invoke()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }
    }
}
