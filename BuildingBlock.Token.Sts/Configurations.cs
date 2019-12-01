using System;
using System.Net.Http;
using BuildingBlock.Token.Sts.ExternalServices;
using BuildingBlock.Token.Sts.ExternalServices.Models;
using BuildingBlock.Token.Sts.HttpMessageHandler;
using BuildingBlock.Token.Sts.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace BuildingBlock.Token.Sts
{
    public static class Configurations
    {
    
        public static IServiceCollection AddTokenAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddRefitClient<IAuthenticationService>()
                    .ConfigureHttpClient(client => client.BaseAddress = new Uri(configuration["SLACK_STS_ENDPOINT"]))
                    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    });

            services.AddScoped<AuthorizationHandler>();

            services.AddSingleton<IAuthentication, Authentication>();

            return services;
        }


    }
}
