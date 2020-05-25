using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Snowman.Tourist.Spots.Shared.API.Settings;

namespace Snowman.Tourist.Spots.Shared.API.IoC
{
    public static class APIInjectorBootStrapper
    {
        public static void InitializeAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiOptions>(configuration.GetSection("API"));
            services.Configure<AuthenticationOptions>(configuration.GetSection("AUTHENTICATION"));
        }
    }
}
