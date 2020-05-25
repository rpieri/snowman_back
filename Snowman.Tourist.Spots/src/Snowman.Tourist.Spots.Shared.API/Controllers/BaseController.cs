using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using Snowman.Tourist.Spots.Shared.ViewModels;
using System;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.API.Controllers
{
    public abstract class BaseController<TController> : ControllerBase where TController : BaseController<TController>
    {
        protected readonly IMediatorHandler mediator;

        public BaseController(IMediatorHandler mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> ResponseBase(CommandResult commandResult)
        {
            if (commandResult != null)
            {
                if (commandResult.Success)
                {

                    return await Task.Run(() => new OkObjectResult(commandResult));
                }

                return await Task.Run(() => new BadRequestObjectResult(commandResult));
            }
            return await Task.Run(() => new BadRequestResult());
        }


        protected async Task<CommandResult> SendCommand(Command command)
            => await mediator.SendAsync(command);

        protected async Task<IActionResult> ReturnCommand(Command command)
        {
            var result = await SendCommand(command);
            return await ResponseBase(result);
        }
        protected async Task<IActionResult> Execute<TCommand, TViewModel>(TViewModel viewModel)
            where TCommand : Command
            where TViewModel : ViewModelToCommand<TCommand>
        {
            var command = viewModel.Mapping();
            return await ReturnCommand(command);
        }
    }
}
