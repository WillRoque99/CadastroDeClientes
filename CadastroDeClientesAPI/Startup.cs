using Autofac;
using CadastroDeClientes.Application;
using CadastroDeClientes.Application.Interfaces;
using CadastroDeClientes.Domain.Core.Interface.Repositorys;
using CadastroDeClientes.Domain.Core.Interface.Services;
using CadastroDeClientes.Infastructure.CrossCuting.IOC;
using CadastroDeClientes.Infastructure.Data;
using CadastroDeClientes.Infastructure.Data.Repositoryss;
using CadastroDeClientes.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CadastroDeClientesAPI
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
             var connection = Configuration["SqlConnection:SqlconnectionString"];
            services.AddDbContext<ClienteContext>(options => options.UseSqlServer(connection)); 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cadastro De Cliente", Version = "v1" });
            });

           // services.AddScoped<Interface, classe implementado> ();
            services.AddScoped<IApplicationServiceCliente, ApplicationServiceCliente>();
            services.AddScoped<IServiceCliente, ServiceCliente>();
            services.AddScoped<IRepositoryCliente, RepositoryCliente>();

        }
         public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuleIOC());
       }
         //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cadastro De Cliente");
               } ); 


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
