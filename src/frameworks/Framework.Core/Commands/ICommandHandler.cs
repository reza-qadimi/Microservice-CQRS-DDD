namespace Framework.Core.Commands;

public interface ICommandHandler<T> where T : ICommand
{
	void Handle(T command);

	System.Threading.Tasks.Task HandleAsync(T command);
}
