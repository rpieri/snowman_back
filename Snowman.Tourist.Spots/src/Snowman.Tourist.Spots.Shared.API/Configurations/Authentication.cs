using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Snowman.Tourist.Spots.Shared.API.Settings;
using Snowman.Tourist.Spots.Shared.IoC;

namespace Snowman.Tourist.Spots.Shared.API.Configurations
{
    public static class Authentication
    {
        public static void AddAuthenticationAPI(this IServiceCollection services)
        {
            var setting = SettingsOperations.GetConfiguration<AuthenticationOptions>(services);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = setting.Authority;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = setting.Issuer,
                        ValidateAudience = true,
                        ValidAudience = setting.Audience,
                        ValidateLifetime = true
                    };
                });
        }

        public static void UseAuthenticationAPI(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
