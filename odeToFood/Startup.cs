using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using odeToFood.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using odeToFood.Controllers;

namespace odeToFood
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration
        {
            get;
            set;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                             IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute("about", "{controller=About}/{action}");
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                //routes.MapRoute("about", "{controller=About}/{action}");
            }
                      );
                      

            app.Run(async (context) =>
            {
                var headers = context.Request.Headers;
                var greeting = greeter.GetGreeting();
                foreach (string h in headers.Keys)
                {

                    await context.Response.WriteAsync(h +": " + headers[h] + "\n");
                }
            });
        }

 /*       private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            //routeBuilder.MapRoute("About", "{controller=About}/{action}");
            routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}");
        }
        */
    }
}
