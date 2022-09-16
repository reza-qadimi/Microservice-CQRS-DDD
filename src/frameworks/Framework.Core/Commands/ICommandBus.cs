namespace Framework.Core.Commands;

public interface ICommandBusSync<in I, O> where I : ICommand<O>
{
	O Send(I command);
}

public interface ICommandBusSync<in I> where I : ICommand
{
	void Send(I command);
}

public interface ICommandBusAsync<in I> where I : ICommand
{
	System.Threading.Tasks.Task Send
		(I command, System.Threading.CancellationToken cancellationToken = default);
}

public interface ICommandBusAsync<in I, O> where I : ICommand<O>
{
	System.Threading.Tasks.Task<O> Send
		(I command, System.Threading.CancellationToken cancellationToken = default);
}
