using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.Domain.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.API.Filters
{
    internal sealed class NotificationFilter : IAsyncResultFilter
    {
        private readonly ILogger<NotificationFilter> logger;
        private readonly NotificationContext notificationContext;

        public NotificationFilter(
            ILogger<NotificationFilter> logger,
            NotificationContext notificationContext)
        {
            this.logger = logger;
            this.notificationContext = notificationContext;
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (notificationContext.HasNotification)
            {
                var messageReturn = new List<string>();
                var log = new StringBuilder();
                var messages = notificationContext.Notifications.Select(x => x.Message).ToList();


                messages.ForEach(message =>
                {
                    log.Append(message);
                    var dados = message.Split(";");
                    messageReturn.Add(message);
                });


                var result = new CommandResult(false, messageReturn);


                logger.LogError(log.ToString());

                context.Result = new BadRequestObjectResult(result);
            }
            await next();
        }
    }
}
