using Snowman.Tourist.Spots.Shared.Domain.Commands;

namespace Snowman.Tourist.Spots.Shared.ViewModels
{
    public abstract class ViewModelToCommand<TCommand> : ViewModel where TCommand : Command
    {
        public abstract TCommand Mapping();
    }
}
