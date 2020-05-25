using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Snowman.Tourist.Spots.Domain.Users.CommandHandlers;
using Snowman.Tourist.Spots.Domain.Users.Commands;
using Snowman.Tourist.Spots.Domain.Users.Repositories;
using Snowman.Tourist.Spots.Repository.Contexts;
using Snowman.Tourist.Spots.Repository.Repositories;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using Snowman.Tourist.Spots.Shared.Repository.UoW;
using System.ComponentModel.Design;

namespace Snowman.Tourist.Spots.IoC
{
    public static class InjectorBootStrapper
    {
        public static void TouristSpotsServices(this IServiceCollection services, IConfiguration configuration, bool usingInMemory = false)
        {
            services.AddDbContext<EntityContext>(opt => {
                if (usingInMemory)
                {
                    opt.UseInMemoryDatabase("DataBase");
                }
                else
                {
                    opt.UseSqlServer(configuration.GetConnectionString("Default"));
                }
            });

            services.AddScoped<IUnitOfWork, UnitOfWork<EntityContext>>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRequestHandler<AddUserCommand, CommandResult>, AddUserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, CommandResult>, UpdateUserCommandHandler>();            
        }
    }
}
