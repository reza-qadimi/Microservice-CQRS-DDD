namespace Framework.Core.Commands;

public interface ICommandHandlerSync<in I, O> where I : ICommand<O>
{
	O Handle(I command);
}

public interface ICommandHandlerAsync<in I, O> where I : ICommand<O>
{
	System.Threading.Tasks.Task<O> Handle(I command);
}

public interface ICommandHandlerSync<in I> where I : ICommand
{
	void Handle(I command);
}

public interface ICommandHandlerAsync<in I> where I : ICommand
{
	System.Threading.Tasks.Task Handle(I command);
}
