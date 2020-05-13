using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using PizzaKunphai.Data.Interfaces;
using PizzaKunphai.Data.Models;
using Microsoft.Extensions.Configuration;
using PizzaKunphai.Data;
using Microsoft.EntityFrameworkCore;
using PizzaKunphai.Data.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PizzaKunphai
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
         .SetBasePath(hostingEnvironment.ContentRootPath)
         .AddJsonFile("appsettings.json")
         .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                //Server configuration
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

                services.AddIdentity<IdentityUser, IdentityRole>()
                        .AddEntityFrameworkStores<AppDbContext>();

                services.AddTransient<IFoodRepository, FoodRepository>();
                services.AddTransient<ICategoryRepository, CategoryRepository>();
                services.AddTransient<IOrderRepository, OrderRepository>();


                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.AddScoped(sp => ShoppingCart.GetCart(sp));

                services.AddMvc();
                services.AddMemoryCache();
                services.AddSession();
            }
            catch (Exception)
            {

                throw;
            }           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes=>
            {
                routes.MapRoute(name:"categoryFilter",template:"Drink/{action}/{category?}",defaults:new { Controller ="Drink",action="List"});
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{Id?}");
            });

            DbInitializer.Seed(app);
        }
    }
}
