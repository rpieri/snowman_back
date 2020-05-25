using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.API.Filters
{
    public class NotificationViewModelFilter : IAsyncActionFilter
    {
        private readonly ILogger<NotificationViewModelFilter> logger;

        public NotificationViewModelFilter(ILogger<NotificationViewModelFilter> logger)
        {
            this.logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var messages = new List<string>();
            var values = context.ActionArguments.Where(x => x.Key.ToLower().Equals("viewModel")).Select(x => x.Value).FirstOrDefault();
            if (values is IEnumerable<ViewModel>)
            {
                var listValues = values as IEnumerable<ViewModel>;
                listValues.ToList().ForEach(obj =>
                {
                    VerifyViewModel(obj, ref messages);
                });
            }
            else if (values is ViewModel)
            {
                VerifyViewModel(values, ref messages);
            }

            if (messages.Count > 0)
            {
                var log = new StringBuilder();
                messages.ForEach(m => log.Append(m));
                logger.LogError(log.ToString());

                context.Result = new BadRequestObjectResult(new CommandResult(false, messages));
                return;
            }


            await next();
        }

        public void VerifyViewModel(object obj, ref List<string> messages)
        {
            var viewModel = obj as ViewModel;
            if (!viewModel.Validate())
            {
                var message = viewModel.ValidationResult.Errors.Select(err => err.ErrorMessage).ToList();
                messages.AddRange(message);
            }
        }
    }
}
