using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            //services.AddControllers() // web api only
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory() + "\\MyStaticFiles")),
                RequestPath = "/MyStaticFiles"
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!</br>" + env.EnvironmentName + "</br>");
                //    if (env.IsDevelopment())
                //    {
                //        await context.Response.WriteAsync("Hello developer");
                //    }
                //    else if (env.IsProduction())
                //    {
                //        await context.Response.WriteAsync("Hello production");
                //    }
                //    else if (env.IsStaging())
                //    {
                //        await context.Response.WriteAsync("Hello staging");
                //    }
                //    else
                //        await context.Response.WriteAsync("Unknown");
                //});

                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "bookapp/{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/ruddor", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello Ruddor!</br>" + env.EnvironmentName);
            //    });
            //});
        }
    }
}
