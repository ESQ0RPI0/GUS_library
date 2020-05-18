using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUS_book.Extensions.Services;
using GUS_book.Models.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer;

namespace GUS_book
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
       
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connection));
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
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseTempHandler("BookList");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Library}/{action=Index}/{id?}");
            });
        }
    }
}
