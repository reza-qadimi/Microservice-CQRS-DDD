namespace UserManagements.Domain.Aggregates.Users;

// TODO: Implementing Domain-Driven Design
public class User : Framework.Domain.Entity<System.Guid>
{
	#region Constant(s)
	public const byte NameMaxLength = 50;

	public const byte UsernameMaxLength = 20;

	public const byte PasswordMaxLength = 64;

	public const byte NationalCodeFixedLength = 10;

	public const byte EmailAddressMaxLength = 254;

	public const byte CellPhoneNumberFixedLength = 11;
	#endregion /Constant(s)

	public User(string username, string password) : base()
	{
		Username = username;

		// TODO: HASH
		Password = password;

		Id = System.Guid.NewGuid();

		InsertDateTime = System.DateTime.Now;
	}

	// **********
	public bool IsActive { get; set; }
	// **********

	// **********
	public string? FirstName { get; set; }
	// **********

	// **********
	public string? LastName { get; set; }
	// **********

	// **********
	public string Password { get; set; }
	// **********

	// **********
	public string Username { get; set; }
	// **********

	// **********
	public string? Description { get; set; }
	// **********

	// **********
	public string? EmailAddress { get; set; }
	// **********

	// **********
	public string? CellPhoneNumber { get; set; }
	// **********

	// **********
	public ValueObjects.UserType Role { get; set; }
	// **********

	// **********
	public System.DateTime InsertDateTime { get; set; }
	// **********
}
