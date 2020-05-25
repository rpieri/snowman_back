using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Snowman.Tourist.Spots.Shared.API.Configurations
{
    public static class MediatR
    {
        public static void AddMediatRAPI<TStartup>(this IServiceCollection services) where TStartup : class
            => services.AddMediatR(typeof(TStartup));
    }
}
