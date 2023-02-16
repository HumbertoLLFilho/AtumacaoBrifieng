using Automacao.Application.Interfaces;
using Automacao.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Automacao.Functions.Configs
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            // Application
            services.AddSingleton<ICodeApplication, CodeApplication>();
            services.AddSingleton<IEnvironmentApplication, EnvironmentApplication>();
            services.AddSingleton<IAssignmentApplication, AssignmentApplication>();

            // Service
            services.AddSingleton<ICodeApplication, CodeApplication>();

            // Infra
            services.AddSingleton<ICodeApplication, CodeApplication>();

            return services;
        }
    }
}
