using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole();

            app.UseStatusCodePagesWithReExecute("/{0}.html");

            app.UseStaticFiles();

            app.Map("/mvc", mvcapp =>
            {
                mvcapp.UseMvcWithDefaultRoute();
            });

            app.UseMiddleware<WelcomePageMiddleware>();

            app.Run(c => c.Response.WriteAsync("Hi."));
        }

    }
}