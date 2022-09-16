namespace UserManagements.Application.Aggregates.Users.CommandHandlers;

public class LoginCommandHandler :
	Framework.Core.Commands.ICommandHandlerAsync
	<Application.Contracts.Aggregates.Users.Commands.LoginCommand,
	UserManagements.Dtos.Aggregates.Users.Commands.LoginResponseDto>
{
	public async System.Threading.Tasks.Task
		<UserManagements.Dtos.Aggregates.Users.Commands.LoginResponseDto>
		Handle
		(Contracts.Aggregates.Users.Commands.LoginCommand command)
	{
		await System.Threading.Tasks.Task.CompletedTask;

		throw new System.NotImplementedException();
	}
}
