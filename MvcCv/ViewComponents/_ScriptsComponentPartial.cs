﻿using Microsoft.AspNetCore.Mvc;

namespace MvcCv.ViewComponents
{
    public class _ScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
