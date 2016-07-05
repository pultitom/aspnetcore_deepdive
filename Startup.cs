using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ConsoleApplication
{
   class Startup
   {
       public void Configure(IApplicationBuilder app) {
            app.Run(c => c.Response.WriteAsync("Hi."));
       }

   }
}