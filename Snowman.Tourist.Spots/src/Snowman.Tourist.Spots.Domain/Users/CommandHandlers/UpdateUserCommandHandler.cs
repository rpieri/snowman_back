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
    public class UpdateUserCommandHandler : CommandEntityHandler<User, UpdateUserCommand>
    {
        private readonly IUserRepository repository;

        public UpdateUserCommandHandler(
            IUserRepository repository,
            IUnitOfWork unitOfWork, 
            NotificationContext notificationContext, 
            IMediatorHandler mediator) : base(unitOfWork, notificationContext, mediator)
        {
            this.repository = repository;
        }

        public override async Task<CommandResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await repository.GetByExternalIdAsync(request.ExternalId);
            if(user == null)
            {
                return await CreateCommandResult(false);
            }

            user.Update(request.Name, request.Email, request.PhoneNumber);

            return await CommitAsync(user, "", user.Id);
        }

        protected override async Task ExecuteCommandAsync(User entity) => await repository.UpdateAsync(entity);
    }
}
