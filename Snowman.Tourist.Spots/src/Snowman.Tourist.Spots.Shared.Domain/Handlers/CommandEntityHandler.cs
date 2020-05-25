using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using Snowman.Tourist.Spots.Shared.Domain.Models;
using Snowman.Tourist.Spots.Shared.Domain.Notifications;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.Domain.Handlers
{
    public abstract class CommandEntityHandler<TEntity, TCommand> : CommandHandler<TCommand> where TEntity : Entity where TCommand : Command
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly NotificationContext notificationContext;

        public CommandEntityHandler(IUnitOfWork unitOfWork, NotificationContext notificationContext, IMediatorHandler mediator) : base(mediator)
        {
            this.unitOfWork = unitOfWork;
            this.notificationContext = notificationContext;
        }

        protected bool Valid(TEntity entity)
        {
            if (entity.Invalid)
            {
                notificationContext.AddNotification(entity.ValidationResult);
                return false;
            }
            return true;
        }

        protected async Task<bool> ValidateAndExecuteCommandAsync(TEntity entity)
        {
            if (Valid(entity))
            {
                await ExecuteCommandAsync(entity);
                return true;
            }
            return false;
        }

        protected async Task<CommandResult> CommitAsync(TEntity entity, string message, object dataReturn = null)
        {
            if(!await ValidateAndExecuteCommandAsync(entity))
            {
                return null;
            }

            if(await unitOfWork.CommitAsync())
            {
                return await CreateCommandResult(true, message, dataReturn);
            }

            return await CreateCommandResult(false);
        }

        protected abstract Task ExecuteCommandAsync(TEntity entity);
    }
}
