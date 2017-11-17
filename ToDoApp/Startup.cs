using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Infrastructure.Data.Contracts;
using ToDoApp.Infrastructure.Data.Repositories;
using ToDoApp.Core.Contracts;
using ToDoApp.Core.Services;

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
            services.AddDbContext<ToDoContext>(options => options
                .UseNpgsql(Configuration.GetConnectionString("PostgreConnection"), 
                p => p.MigrationsAssembly("ToDoApp")));

            services.AddScoped(typeof(IRDBERepository<>), typeof(RDBERepository<>));

            services.AddScoped<IToDoService, ToDoService>();

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
