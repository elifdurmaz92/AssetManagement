using AssetManagement.BLL.Provider;
using AssetManagement.UI.Models.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI
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
            services.AddMvc(x=> {
                x.EnableEndpointRouting = false;
            }).SetCompatibilityVersion( Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddControllersWithViews();
            #region Auto Mapper Configurations

            services.AddAutoMapper(typeof(Startup));
            #endregion

            services.AddHttpClient<NewAssetProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });
            services.AddHttpClient<AssetProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });

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

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

        }
    }
}
