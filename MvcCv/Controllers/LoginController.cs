using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;
using MvcCv.DAL.Entities;
using MvcCv.Repositories;
using System.Security.Claims;

namespace MvcCv.Controllers
{
	public class LoginController : Controller
	{
		GenericRepository<User> repo = new GenericRepository<User>();
		
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(string username, string password)
		{
			var user = repo.Find(x=> x.UserName == username && x.Password == password);
			if (user != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var authProperties = new AuthenticationProperties
                {
                    // Kullanıcı giriş bilgilerini hatırlama
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

				return RedirectToAction("Index", "Contact");
			}
			ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifre yanlış!";
			return View();
		}
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync("Cookies");
			return RedirectToAction("Login");
		}
        public IActionResult SetSessionData()
        {
            HttpContext.Session.SetString("UserName", "admin");
            HttpContext.Session.SetInt32("UserId", 123);
            return RedirectToAction("Index");
        }
        public IActionResult GetSessionData()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var userId = HttpContext.Session.GetInt32("UserId");

            ViewBag.UserName = userName ?? "Oturum Yok";
            ViewBag.UserId = userId ?? 0;

            return View();
        }
        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
