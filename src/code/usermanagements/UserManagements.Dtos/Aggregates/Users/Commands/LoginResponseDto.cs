namespace UserManagements.Dtos.Aggregates.Users.Commands
{
	public class LoginResponseDto : object
	{
		public LoginResponseDto
			(string username, System.Guid id, string token, string role) : base()
		{
			Id = id;
			Role = role;
			Token = token;
			Username = username;
		}

		public string Role { get; set; }

		public string Token { get; set; }

		public string Username { get; set; }

		public System.Guid Id { get; set; }
	}
}
