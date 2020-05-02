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
using System.Reflection;
using DAL.Configuration;

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
            //services.AddDbContext<FrendsMapContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("FrendsMapContext")));

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<FrendsMapContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("FrendsMapContext"), optionsBuilder => optionsBuilder.MigrationsAssembly(migrationsAssembly)));

            services.Configure<AzureStorageConfig>(Configuration.GetSection("AzureStorageConfig"));
            //services.AddSingleton(x => new String(Configuration.GetValue<string>("AzureBlobStorageConnectionString")));
            // services.AddSingleton<IBlobService, BlobService>();

            services.AddTransient<IPlaceService, PlaceService>();
            services.AddTransient<ITypeOfPlaceService, TypeOfPlaceService>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IRankingService,RankingService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<IRankingOfFriendService, RankingOfFriendService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          //
            services.AddMvc(mvcOptions => { mvcOptions.EnableEndpointRouting = false; });
            EntityFrameworkProfiler.Initialize();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,FrendsMapContext context)
        {
            //
            //context.Database.Migrate();

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
