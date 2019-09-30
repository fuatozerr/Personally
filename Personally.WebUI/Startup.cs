using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Personally.Business.Abstract;
using Personally.Business.Concrete;
using Personally.DataAccess.Abstract;
using Personally.DataAccess.Concrete;
using Personally.WebUI.Middlewares;

namespace Personally.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            services.AddScoped<INoteDal, EfCoreNoteDal>();
            services.AddScoped<ICategoryService, ICategoryManager>();
            services.AddScoped<INoteService, INoteManager>();


            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2); //mvc şekli
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }

            app.UseStaticFiles(); //wwwroot klasörünü açıyorum
            app.StandartStaticFile();



            app.UseMvc(routes => {

                routes.MapRoute(
                    name: "notes",
                    template: "notes/{category?}",
                    defaults:new {controller="Note",action="List"});


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
