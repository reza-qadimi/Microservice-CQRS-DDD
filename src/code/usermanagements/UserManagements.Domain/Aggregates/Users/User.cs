namespace UserManagements.Domain.Aggregates.Users;

public class User : Framework.Domain.Entity<ValueObjects.Id>
{
	#region Static Member(s)
	public static
		CustomResult.Result<User>
		Create(string username, string password,
		string emailAddress, string cellPhoneNumber,
		bool? isActive, bool? isIPRestricted, int? type,
		int? gender, string firstName, string lastName, string description)
	{
		var result =
			new CustomResult.Result<User>();

		// **************************************************
		var usernameResult =
			ValueObjects.Username.Create(value: username);

		result.WithErrors
			(errorMessages: usernameResult.Errors);
		// **************************************************

		// **************************************************
		var passwordResult =
			ValueObjects.Password.Create(value: password);

		result.WithErrors
			(errorMessages: passwordResult.Errors);
		// **************************************************

		// **************************************************
		var isActiveResult =
			SharedKernel.IsActive.Create(value: isActive);

		result.WithErrors
			(errorMessages: isActiveResult.Errors);
		// **************************************************

		// **************************************************
		var roleResult =
			ValueObjects.Role.GetByValue(value: type);

		result.WithErrors
			(errorMessages: roleResult.Errors);
		// **************************************************

		// **************************************************
		var fullNameResult =
			SharedKernel.FullName.Create
			(firstName: firstName, lastName: lastName);

		result.WithErrors
			(errorMessages: fullNameResult.Errors);
		// **************************************************

		if (result.IsSuccess == false)
		{
			return result;
		}

		var returnValue = new User
			(role: roleResult.Value,
			username: usernameResult.Value,
			password: passwordResult.Value,
			isActive: isActiveResult.Value,
			fullName: fullNameResult.Value);

		result.WithValue(value: returnValue);

		return result;
	}
	#endregion /Static Member(s)

	private User() : base()
	{
	}

	private User
		(ValueObjects.Role role,
		ValueObjects.Username username,
		ValueObjects.Password password,
		SharedKernel.IsActive isActive,
		SharedKernel.FullName fullName) : this()
	{
		Role = role;
		FullName = fullName;
		Username = username;
		Password = password;
		IsActive = isActive;
	}

	// **********
	public SharedKernel.IsActive IsActive { get; set; }
	// **********

	// **********
	public SharedKernel.FullName FullName { get; set; }
	// **********

	// **********
	public ValueObjects.Password Password { get; set; }
	// **********

	// **********
	public ValueObjects.Username Username { get; set; }
	// **********

	// **********
	public ValueObjects.Role Role { get; set; }
	// **********
}
