using Snowman.Tourist.Spots.Domain.Users.Commands;
using Snowman.Tourist.Spots.Domain.Users.Models;
using Snowman.Tourist.Spots.Domain.Users.Repositories;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.Domain.Handlers;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using Snowman.Tourist.Spots.Shared.Domain.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Domain.Users.CommandHandlers
{
    public class AddUserCommandHandler : CommandEntityHandler<User, AddUserCommand>
    {
        private readonly IUserRepository repository;

        public AddUserCommandHandler(
            IUserRepository repository,
            IUnitOfWork unitOfWork, 
            NotificationContext notificationContext, 
            IMediatorHandler mediator) : base(unitOfWork, notificationContext, mediator)
        {
            this.repository = repository;
        }

        public override async Task<CommandResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = request.Mapping();

            var user = await repository.GetByExternalIdAsync(request.ExternalId);
            if (user != null)
            {
                if(user != newUser)
                {
                    var updateCommand = new UpdateUserCommand(newUser.ExternalId, newUser.Name, newUser.Email, newUser.PhoneNumber);
                    return await SendCommandAsync(updateCommand);
                }
                else
                {
                    return await CreateCommandResult(true, user.Id);
                }
            }
            return await CommitAsync(newUser, "", newUser.Id);
        }

        protected override async Task ExecuteCommandAsync(User entity) => await repository.AddAsync(entity); 
    }
}
