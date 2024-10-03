using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents
{
    public class _EducationComponentPartial : ViewComponent
    {
        MvcCvContext context = new MvcCvContext();
        public IViewComponentResult Invoke()
        {
            var values = context.Educations.ToList();
            return View(values);
        }
    }
}
