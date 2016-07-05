using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApplication
{
   class Startup
   {
       public void ConfigureServices(IServiceCollection services) {
           services.AddMvc();
       }
       public void Configure(IApplicationBuilder app) {
            app.Map("/mvc", mvcapp => {
                mvcapp.UseMvcWithDefaultRoute();
            });
            app.Run(c => c.Response.WriteAsync("Hi."));
       }

   }
}