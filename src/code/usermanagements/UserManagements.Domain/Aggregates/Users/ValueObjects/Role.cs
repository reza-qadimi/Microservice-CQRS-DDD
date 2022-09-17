namespace UserManagements.Domain.Aggregates.Users.ValueObjects;

public class Role : SharedKernel.Enumeration
{
	#region Constant(s)
	public const int MaxLength = 50;
	#endregion /Constant(s)

	#region Static Member(s)
	public static readonly Role User = new(value: 0, name: nameof(User));
	public static readonly Role Administrator = new(value: 1, name: nameof(Administrator));
	public static readonly Role Owner = new(value: 2, name: nameof(Owner));
	public static readonly Role Developer = new(value: 3, name: nameof(Developer));

	public static CustomResult.Result<Role> GetByValue(int? value)
	{
		var result =
			new CustomResult.Result<Role>();

		// **************************************************
		var typeResult = GetByValue<Role>
			(value: value, name: nameof(Role));
		// **************************************************

		// **************************************************
		if (typeResult.IsSuccess == false)
		{
			result.WithErrors
				(errorMessages: typeResult.Errors);

			return result;
		}
		// **************************************************

		var returnValue = new Role
			(value: typeResult.Value.Value,
			name: typeResult.Value.Name);

		result.WithValue(value: returnValue);

		return result;
	}
	#endregion /Static Member(s)

	private Role() : base()
	{
	}

	private Role(int value, string name) : base(value: value, name: name)
	{
	}
}
