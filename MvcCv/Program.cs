using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MvcCv.DAL.Context;

namespace MvcCv
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/Login/Login";  // Login sayfas�
        options.AccessDeniedPath = "/Login/Login";
        options.LogoutPath = "/Login/Login"; // Logout i�lemi
		options.ExpireTimeSpan = TimeSpan.FromMinutes(2); // Cookie'nin ge�erlilik s�resi
	});

			var app = builder.Build();


			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

            app.UseAuthentication();  // Kimlik do�rulama middleware
            app.UseAuthorization();

            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();

		}
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();  // Session'lar i�in sunucu belle�i kullan�m�
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Session'�n sona erme s�resi
                options.Cookie.HttpOnly = true;                // �erezlerin sadece HTTP �zerinden eri�ilebilir olmas�
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession();          // Session'� aktif hale getirme
            app.UseAuthentication();   // Kimlik do�rulama
            app.UseAuthorization();    // Yetkilendirme

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }

    }
}