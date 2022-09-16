namespace Framework.Core.Notifications;

public interface IPushNotification<I> where I : INotification
{
	System.Threading.Tasks.Task PublishAsync(I notification);
}
