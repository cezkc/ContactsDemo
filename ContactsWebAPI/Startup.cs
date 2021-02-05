using System.IO;
using ContactsDemo.Configuration;
using ContactsWebAPI.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace ContactsWebAPI
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

            services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
             {
                 options.InvalidModelStateResponseFactory = actionContext =>
                 {
                     var modelState = actionContext.ModelState.Values;
                     return new BadRequestObjectResult(new ErrorModel(modelState));
                 };
             });
                 services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "Contacts Demo",
                    Version = "v1",
                    Description = "Contact List",
                    Contact = new OpenApiContact
                    {
                        Name = "Cezar K de Carvalho",
                        Email = "cezar_kc@hotmail.com"
                    }
                });

                string applicationPath =
                PlatformServices.Default.Application.ApplicationBasePath;

                string applicationName =
                PlatformServices.Default.Application.ApplicationName;

                string xmlPathDoc =
                Path.Combine(applicationPath, $"{applicationName}.xml");

                swagger.IncludeXmlComments(xmlPathDoc);

            });

                 ConfigureDependencies.BuildDependencies(services);

             }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json",
                        "Contacts API");
                });
            }
        }
    }
