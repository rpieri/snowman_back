using Microsoft.Extensions.DependencyInjection;
using Snowman.Tourist.Spots.Shared.API.Filters;

namespace Snowman.Tourist.Spots.Shared.API.Configurations
{
    public static class Filter
    {
        public static void UseFilterAPI(this IServiceCollection services)
        {
            services.AddControllers(c =>
            {
                c.Filters.Add<NotificationViewModelFilter>();
                c.Filters.Add<NotificationFilter>();
            });
        }
    }
}
