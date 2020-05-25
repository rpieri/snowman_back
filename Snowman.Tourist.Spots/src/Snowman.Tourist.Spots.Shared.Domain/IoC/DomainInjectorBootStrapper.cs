using Microsoft.Extensions.DependencyInjection;
using Snowman.Tourist.Spots.Shared.Domain.Handlers;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using Snowman.Tourist.Spots.Shared.Domain.Notifications;

namespace Snowman.Tourist.Spots.Shared.Domain.IoC
{
    public static class DomainInjectorBootStrapper
    {
        public static void InitializeDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<NotificationContext>();
        }
    }
}
