using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FietsenWinkel
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Define DBconnection to use SQL server
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DataConnection")));

            // Instantiate classes from DAL
            // not part of exercice, created in video tutorial
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IShoppingItemRepository, ShoppingItemRepository>();
            services.AddTransient<IShoppingBagRepository, ShoppingBagRepository > ();

            // Instantiate classes from BLL 
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IShoppingBagService, ShoppingBagService>();
            services.AddTransient<IShoppingItemService, ShoppingItemService>();

            // not part of exercice, created in video tutorial
            services.AddTransient<IUserService, UserService>();
            
            
            // allow use of MVC principle
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //This part is from  the video tutorial 

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseStatusCodePages();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy(); 
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
