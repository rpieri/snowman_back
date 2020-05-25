using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Snowman.Tourist.Spots.Shared.API.Configurations
{
    public static class Log
    {
        public static void AddLogAPI(this IServiceCollection services)
            => services.AddLogging(opt => 
            {
                opt.AddConsole(c => c.TimestampFormat = "[yyy-MM-dd HH:mm:ss]");
            });
    }
}
