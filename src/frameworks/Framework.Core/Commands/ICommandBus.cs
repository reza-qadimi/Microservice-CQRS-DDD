namespace Framework.Core.Commands;

public interface ICommandBus<TInput, TOutput> where TInput : ICommand
{
	void Send(TInput command);

	System.Threading.Tasks.Task SendAsync(TInput command);
}
