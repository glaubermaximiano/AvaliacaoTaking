using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Taking.Dominio.Config;
using Taking.Infra.IOC;
using Taking.WebApi.Configuration;

namespace Taking.WebApi
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var _conf = new ConfigAmbiente();
            Configuration.Bind("ConfigAmbiente", _conf);
            services.AddSingleton(_conf);

            services.AddControllers()
                    .AddJsonOptions(options => {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });

            services.AddSwaggerConfiguration();

            Dependencia.RegistrarDependencias(services);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()   // Permite qualquer origem
                          .AllowAnyHeader()   // Permite qualquer cabeçalho
                          .AllowAnyMethod();  // Permite qualquer método (GET, POST, etc.)
                });
            });

            services.AddControllers();            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();  //

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
