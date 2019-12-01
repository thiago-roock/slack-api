using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Refit;
using MediatR;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;
using slack.Domain.ExternalServices;
using slack.API.Behaviors;

namespace slack.Api
{
    static class Configurations
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRefitClient<ISlackExternalService>()
                    .ConfigureHttpClient(client => client.BaseAddress = new Uri(configuration["SLACK_ENDPOINT"]))
                    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    });

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services, Assembly assembly, bool enableLogginBehavior = true, bool enableValidatorBehavior = true)
        {
            if (enableLogginBehavior)
                services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            if (enableValidatorBehavior)
                services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            services.AddMediatR(assembly);

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblyName = Assembly.GetCallingAssembly().GetName();

            var version = string.Concat("v", assemblyName.Version);

            services.AddSwaggerGen(setup =>
            {
                var swaggerInfo = new OpenApiInfo
                {

                    Title = assemblyName.Name,
                    Version = version
                };

                setup.SwaggerDoc(swaggerInfo.Version, swaggerInfo);



                setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                var XmlDocPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, string.Concat(PlatformServices.Default.Application.ApplicationName, ".xml"));

                if (File.Exists(XmlDocPath))
                    setup.IncludeXmlComments(XmlDocPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            var version = string.Concat("v", Assembly.GetCallingAssembly().GetName().Version);

            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint($"/swagger/{version}/swagger.json", version);
            });

            return app;
        }
    }
}
