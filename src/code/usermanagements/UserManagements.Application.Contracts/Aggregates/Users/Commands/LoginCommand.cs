namespace UserManagements.Application.Contracts.Aggregates.Users.Commands;

public class LoginCommand : object, Framework.Core.Commands.ICommand
	<UserManagements.Dtos.Aggregates.Users.Commands.LoginResponseDto>
{
	public LoginCommand() : base()
	{
	}

	public string? Username { get; set; }

	public string? Password { get; set; }
}
