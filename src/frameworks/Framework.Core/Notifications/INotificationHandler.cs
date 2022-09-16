namespace Framework.Core.Notifications;

public interface INotificationHandler<T> where T : INotification
{
	System.Threading.Tasks.Task HandleAsync(T notification);
}

