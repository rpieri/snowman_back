using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Snowman.Tourist.Spots.IoC;
using Snowman.Tourist.Spots.Repository.Contexts;
using Snowman.Tourist.Spots.Shared.API.Configurations;
using Snowman.Tourist.Spots.Shared.API.IoC;
using Snowman.Tourist.Spots.Shared.API.Settings;
using Snowman.Tourist.Spots.Shared.Domain.IoC;

namespace Snowman.Tourist.Spots.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.InitializeAPIServices(configuration);
            services.InitializeDomainServices();


            services.TouristSpotsServices(configuration);

            services.AddSwaggerAPI();
            services.AddCorsAPI();
            services.AddVersionAPI();
            services.AddResponseCompressionAPI();
            services.AddMediatRAPI<Startup>();
            services.AddLogAPI();
            services.UseFilterAPI();
            services.AddAuthenticationAPI();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<ApiOptions> options, IApiVersionDescriptionProvider provider, EntityContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            context.ExecuteMigrations();
            
            app.UseCorsAPI();
            app.UseSwaggerAPI(options, provider);
            app.UseResponseCompressionAPI();
            app.UseHttpsRedirectionAPI();
            app.UseStaticFileAPI();
            app.UseRoutingAPI();
            app.UseAuthenticationAPI();
            app.UseEndPointsAPI();

        }
    }
}
