using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Automacao.Functions.Configs;

[assembly: FunctionsStartup(typeof(Automacao.Functions.Startup))]

namespace Automacao.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();

            builder.Services.ConfigureServices();
        }
    }
}