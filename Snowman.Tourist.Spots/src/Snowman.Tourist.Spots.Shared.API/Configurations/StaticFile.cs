using Microsoft.AspNetCore.Builder;

namespace Snowman.Tourist.Spots.Shared.API.Configurations
{
    public static class StaticFile
    {
        public static void UseStaticFileAPI(this IApplicationBuilder app)
            => app.UseStaticFiles();
    }
}
