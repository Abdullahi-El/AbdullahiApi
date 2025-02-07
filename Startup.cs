using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EncryptionApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Här registreras tjänster som behövs för API:t, t.ex. controllers
            services.AddControllers();  // Registrerar controllers som kan hantera inkommande anrop
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // Visar detaljerade fel i utvecklingsmiljö
            }

            app.UseRouting();  // Sätt upp routing för inkommande begärningar

            app.UseEndpoints(endpoints =>
            {
                // Här definieras vilka controllers som ska hantera inkommande begärningar
                endpoints.MapControllers();  // Mappar alla controllers
            });
        }
    }
}
