using Microsoft.AspNetCore.Mvc;

namespace MvcCv.ViewComponents
{
    public class _HeaderComponentPartial : ViewComponent
    {   
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
