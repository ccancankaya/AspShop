using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Database;
using Shop.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration _config { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(_config["DefaultConnection"]));
        }
        //"Server=DESKTOP-RT1H2FS\\MAINDB;Database=ECommerce;Trusted_Connection=true;MultipleActiveResultSets=true"
        //"Server=DESKTOP-3LDF8NN\\SQLEXPRESS;Database=ECommerce;Trusted_Connection=true;MultipleActiveResultSets=true"


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                //Added for use name of controllers
                endpoints.MapControllers();
            });
        }
    }
}
