using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AssetManagement.Core.Context;
using Microsoft.EntityFrameworkCore;
using AssetManagement.DAL;
using AssetManagement.Data.Repository.AuthRepo;
using AutoMapper;
using AssetManagement.Data.Mapping;

namespace AssetManagement.API
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

            services.AddDbContext<AuthContext>(a => a.UseSqlServer(Configuration.GetConnectionString("DefaultConn")));
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            #region Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
               {
                   mc.AddProfile(new MapProfile());
               });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region DAL

            services.AddScoped<IAuthRepo, AuthRepo>();
            services.AddScoped<IAuthDAL, AuthDAL>();
            services.AddScoped<IAssetTypeDAL, AssetTypeDAL>();
            services.AddScoped<IAssetGroupDAL, AssetGroupDAL>();
            services.AddScoped<IAssetBrandDAL, AssetBrandDAL>();
            services.AddScoped<IAssetModelDAL, AssetModelDAL>();
            services.AddScoped<ICurrencyDAL, CurrencyDAL>();
            services.AddScoped<IUnitDAL, UnitDAL>();
            services.AddScoped<IPriceDAL, PriceDAL>();


            #endregion


            var tkn = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);
            services.AddAuthentication();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(tkn),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };


                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "AssetManagementApi",
                    Version = "v1"

                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssetManagementApi v1"));
            }

            app.UseRouting();

            app.UseCors();
            app.UseCors(builder => builder.WithOrigins("http://localhost:25206").AllowAnyHeader());

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
