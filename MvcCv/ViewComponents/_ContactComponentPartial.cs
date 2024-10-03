using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;
using MvcCv.DAL.Entities;

namespace MvcCv.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
        MvcCvContext _context = new MvcCvContext();

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
