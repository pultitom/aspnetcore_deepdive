using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
   class Startup
   {
       public void ConfigureServices(IServiceCollection services) {
           services.AddMvc();
       }
       public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory) {

           loggerFactory.AddConsole();

           app.UseStaticFiles();

           app.UseStatusCodePagesWithReExecute("/error");

           app.Map("/error", errorApp => {
               errorApp.Run(async r => await r.Response.WriteAsync("There was an error. Status code " + r.Response.StatusCode));
           });

           app.Map("/mvc", mvcapp => {
               mvcapp.UseMvcWithDefaultRoute();
           });
           
           
           app.Run(c => c.Response.WriteAsync("Hi."));
       }

   }
}