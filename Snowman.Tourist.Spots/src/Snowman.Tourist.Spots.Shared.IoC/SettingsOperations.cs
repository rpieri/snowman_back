using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Snowman.Tourist.Spots.Shared.IoC
{
    public static class SettingsOperations
    {
        public static TSetting GetConfiguration<TSetting>(IServiceCollection services) where TSetting : class, new()
        {
            var provider = services.BuildServiceProvider();
            return GetConfiguration<TSetting>(provider);
        }
        public static TSetting GetConfiguration<TSetting>(IServiceProvider provider) where TSetting : class, new()
            => provider.GetRequiredService<IOptions<TSetting>>().Value;
    }
}
