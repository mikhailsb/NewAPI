using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NewAPI.Dominio.Interfaces;
using NewAPI.Dominio.Servicos;
using NewAPI.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NewAPI", Version = "v1" });
            });
            // Adiciona a interface e a caser de serviço no escopo.
            // Ao chamar a interface o programa automaticamente instanciará a classe.
            services.AddScoped<ICervejaServico, CervejaServico>();
            services.AddScoped<IVinhoServico, VinhoServicos>();

            services.AddScoped<ICervejaRepositorio, CervejaDaperCRUDRepositorio>(s => new CervejaDaperCRUDRepositorio(Configuration.GetConnectionString("SQLServer")));
            services.AddScoped<IVinhoRepositorio, VinhoDapperCRUDRepositorio>(s => new VinhoDapperCRUDRepositorio(Configuration.GetConnectionString("SQLServer")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
