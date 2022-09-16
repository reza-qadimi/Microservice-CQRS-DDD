namespace Framework.Core.Notifications;

public interface INotifier<T> where T : INotification
{
	System.Threading.Tasks.Task PublishAsync(T notification);
}
