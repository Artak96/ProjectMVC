using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectMVC.Controllers;
using ProjectMVC.Core.Interfaces;
using ProjectMVC.Data.Context;
using ProjectMVC.Data.Models;
using ProjectMVC.Data.Repositoryes;

namespace ProjectMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var conString = Configuration["Data:ProjectMVC:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(conString));

            services.AddControllersWithViews();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Post>, PostRepository>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
