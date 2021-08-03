using Autofac;
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TicketSystem.Common.Auth;
using TicketSystem.Common.Swagger;
using TicketSystem.Service.Service;

namespace TicketSystem
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
            services.AddSingleton(new JwtSettings(Configuration["Jwt:Key"], Configuration["Jwt:Issuer"]));
            services.AddControllers(options =>
            {
            });


            services.AddAuth(Configuration);
            services.AddSwagger();
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", " TicketSystem API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            var service = Assembly.Load("TicketSystem.Service");
            var dataAccess = Assembly.Load("TicketSystem.DataAccess");
            var common = Assembly.Load("TicketSystem.Common");

            //builder.RegisterAssemblyTypes(entryAssembly)
            //    .Where(t => t.Name.EndsWith("Filter"))
            //    .PropertiesAutowired();

            builder.RegisterAssemblyTypes(entryAssembly)
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t))
                .PropertiesAutowired()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(service)
                .Where(t => t.Name.EndsWith("Service"))
                .PropertiesAutowired()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Repository"))
                .PropertiesAutowired()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(common)
            //    .Where(t => t.Name.EndsWith("Middleware"))
            //    .PropertiesAutowired();

        }


        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = AppContext.BaseDirectory;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }
    }
}
