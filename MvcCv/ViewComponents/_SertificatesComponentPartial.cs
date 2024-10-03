using Microsoft.AspNetCore.Mvc;
using MvcCv.DAL.Context;

namespace MvcCv.ViewComponents
{
    public class _SertificatesComponentPartial:ViewComponent
    {
        MvcCvContext _context = new MvcCvContext();
        public IViewComponentResult Invoke()
        {
            var certs = _context.Sertificates.ToList();
            return View(certs);
        }
    }
}
