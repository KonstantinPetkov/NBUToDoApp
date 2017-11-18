using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Core.Contracts;
using ToDoApp.Core.Services;
using ToDoApp.Infrastructure.Data.Contexts;
using ToDoApp.Infrastructure.Data.Contracts;
using ToDoApp.Infrastructure.Data.Repositories;

namespace ToDoApp
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
            // Adding DB context. This is the only line we have to change to switch from 
            // MS SQL server to POstgreSQL
            // This is an example of Persistence ignorance principle
            // This is adding PostgreSQL support
            services.AddDbContext<ToDoContext>(options => options
                .UseNpgsql(Configuration.GetConnectionString("PostgreConnection"), 
                p => p.MigrationsAssembly("ToDoApp")));

            // This is adding MS SQL server support
            // services.AddDbContext<ToDoContext>(options => options
            //    .UseSqlServer(Configuration.GetConnectionString("MSSqlConnection"),
            //    p => p.MigrationsAssembly("ToDoApp")));

            // Adding Ralational Database Engine repository to IoC container
            // The scope is per Request, so we will have exactly one instance of this repository per request
            services.AddScoped(typeof(IRDBERepository<>), typeof(RDBERepository<>));

            // Adding ToDo service to IoC container
            services.AddScoped<IToDoService, ToDoService>();

            // Mvc is a cervice too, so we have to add it to IoC in order to build MVC application
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
