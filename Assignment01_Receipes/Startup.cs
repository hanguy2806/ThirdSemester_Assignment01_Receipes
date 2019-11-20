using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment01_Receipes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment01_Receipes
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var connection = "Server = (localdb)\\MSSQLLocalDB; Database = Assignment01_Receipes; Trusted_Connection = True; MultipleActiveResultSets = true";
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:Assignment01_Receipes:ConnectionStrings"]));
            services.AddTransient<IRecipeRepository,EFRecipeRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute(
                  name: null,
                  template: "",
                  defaults: new { controller = "Product", action = "List" });

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List" }
                );
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
