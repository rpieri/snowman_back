using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Snowman.Tourist.Spots.Shared.Domain.Notifications
{
    public sealed class NotificationContext
    {
        private readonly List<Notification> notifications;

        public NotificationContext() => notifications = new List<Notification>();

        public IReadOnlyCollection<Notification> Notifications => notifications.ToList();
        public bool HasNotification => notifications.Any();
        public void AddNotification(ValidationResult validationResult) => validationResult.Errors.ToList().ForEach(error => AddNotification(error.ErrorCode, error.ErrorMessage));
        private void AddNotification(string key, string message) => notifications.Add(new Notification(key, message));
    }
}
