using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using AutoMapper;
using PhoneStore.Interfaces;
using PhoneStore.Repository;
using PhoneStore.Interfaces.Services;
using PhoneStore.Services;
using PhoneStore.Data;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using PhoneStore.CustomHandler;
using PhoneStore.Interfaces.Repository;
using PhoneStore.Interfaces.Repositories;
using PhoneStore.Repositories;
//using PhoneStore.Data;

namespace PhoneStore
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
            services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", config =>
            {
                config.Cookie.Name = "UserLoginCookie";
                config.LoginPath = "/Admin/Login";
                config.AccessDeniedPath = "/Home/Index";
            });
            services.AddAuthorization(config =>
            {
                config.AddPolicy("UserPolicy", policyBuilder =>
                {
                    policyBuilder.UserRequireCustomClaim(ClaimTypes.Name);
                });
            });
            services.AddControllersWithViews();
            services.AddDbContext<PhoneStoreDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PhoneStoreDatabase")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IAdminProductRepo, AdminProductRepo>();
            services.AddScoped<IAdminInvoiceRepo, AdminInvoiceRepo>();
            services.AddScoped<IInvoiceRepo, InvoiceRepo>();
            services.AddScoped(typeof(IRepository<>),typeof( BaseRepository<>));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminProductService, AdminProductService>();
            services.AddScoped<IAdminInvoiceService, AdminInvoiceService>();
            services.AddScoped<ICartService, CartService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
