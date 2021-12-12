using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiClient;

namespace Webserver
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSingleton((webApiClient) => WebApiClientFactory.GetWebApiClient<IWebApiClient>(Configuration["WebApiURI"]));

            services.AddDistributedMemoryCache();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, authOptions =>
            {
                authOptions.LoginPath = "/Users/Login";
                authOptions.LogoutPath = "/Users/Logout";
            });

            services.AddSession(sessOptions =>
            {
                sessOptions.IdleTimeout = TimeSpan.FromSeconds(10);
                sessOptions.Cookie.HttpOnly = true;
                sessOptions.Cookie.IsEssential = true;
                sessOptions.Cookie.SameSite = SameSiteMode.None;
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}"
                );
            });

        }
    }
}
