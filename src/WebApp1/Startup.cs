using System.IO;
using DataPersistence.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace WebApp1
{
    class Startup
    {
        public IConfiguration Configuration { get; set; }
        
        public Startup() {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("mysettings.json", optional: true, reloadOnChange: true);
            
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(provider => Configuration);
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlite("Data Source=MyDatabase.db"));
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }
        
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole();

            app.UseStaticFiles();

            app.Map("/mvc", mvcapp =>
            {
                mvcapp.UseMvcWithDefaultRoute();
            });

            app.Run(c => c.Response.WriteAsync(Configuration["defaultHello"]));
        }

    }
}