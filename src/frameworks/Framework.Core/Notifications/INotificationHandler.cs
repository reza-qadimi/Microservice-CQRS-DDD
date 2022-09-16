namespace Framework.Core.Notifications;

public interface INotificationHandler<I> where I : INotification
{
	System.Threading.Tasks.Task HandleAsync(I notification);
}

