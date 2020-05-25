using Microsoft.AspNetCore.Builder;

namespace Snowman.Tourist.Spots.Shared.API.Configurations
{
    public static class HttpsRedirection
    {
        public static void UseHttpsRedirectionAPI(this IApplicationBuilder app) => app.UseHttpsRedirection();
    }
}
