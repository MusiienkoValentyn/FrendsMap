using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DAL;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using HibernatingRhinos.Profiler.Appender.EntityFramework;

namespace FrendsMap
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

            services.AddControllers();
            services.AddDbContext<FrendsMapContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("FrendsMapContext")));

            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<ITypeOfPlaceService, TypeOfPlaceService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          //
            services.AddMvc(mvcOptions => { mvcOptions.EnableEndpointRouting = false; });
            EntityFrameworkProfiler.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            //
            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
            name: "api",
            template: "api/{controller=Values}/{action=GetAll}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

        }
    }
}
