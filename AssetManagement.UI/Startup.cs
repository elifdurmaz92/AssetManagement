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
using FluentValidation.AspNetCore;
using AssetManagement.DTO.Validation;
using FluentValidation;
using AssetManagement.DTO.VM;

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
            services.AddMvc(x =>
            {
                x.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddControllersWithViews();

            //Validation
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddAssetVMValidator>());


            #region Auto Mapper Configurations

            //services.AddAutoMapper(typeof(Startup));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Provider 
            services.AddHttpClient<AssetTypeProvider>(options =>
             {
                 options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
             });
            services.AddHttpClient<UnitProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });
            services.AddHttpClient<CurrencyProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });
            services.AddHttpClient<AssetModelProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });
            services.AddHttpClient<BrandProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });
            services.AddHttpClient<AssetGroupProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });
            services.AddHttpClient<AssetProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });
            services.AddHttpClient<SystemListsProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });
            services.AddHttpClient<AssetManagementProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });
            services.AddHttpClient<AssetActionProvider>(options =>
            {
                options.BaseAddress = new Uri(Configuration["mybaseAdres"]);
            });

            #endregion



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
                  name: "areas",
                   template: "{area:exists}/{controller=Definition}/{action=SystemLists}/{id?}");
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");

            });

        }
    }
}
