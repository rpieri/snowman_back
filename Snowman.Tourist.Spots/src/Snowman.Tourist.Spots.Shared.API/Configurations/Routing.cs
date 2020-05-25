using Microsoft.AspNetCore.Builder;

namespace Snowman.Tourist.Spots.Shared.API.Configurations
{
    public static class Routing
    {
        public static void UseRoutingAPI(this IApplicationBuilder app)
            => app.UseRouting();
    }
}
