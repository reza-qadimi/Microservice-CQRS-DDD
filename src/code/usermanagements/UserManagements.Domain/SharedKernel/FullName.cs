namespace UserManagements.Domain.SharedKernel;

public class FullName : SeedWork.ValueObject
{
	#region Static Member(s)
	public static CustomResult.Result<FullName>
		Create(string firstName, string lastName)
	{
		var result =
			new CustomResult.Result<FullName>();

		// **************************************************
		var firstNameResult =
			FirstName.Create(value: firstName);

		result.WithErrors(firstNameResult.Errors);
		// **************************************************

		// **************************************************
		var lastNameResult =
			LastName.Create(value: lastName);

		result.WithErrors(lastNameResult.Errors);
		// **************************************************

		if (result.IsSuccess == false)
		{
			return result;
		}

		var returnValue = new FullName
			(firstName: firstNameResult.Value,
			lastName: lastNameResult.Value);

		result.WithValue(value: returnValue);

		return result;
	}
	#endregion /Static Member(s)

	private FullName() : base()
	{
	}

	private FullName
		(FirstName firstName, LastName lastName) : this()
	{
		LastName = lastName;
		FirstName = firstName;
	}

	public LastName LastName { get; }

	public FirstName FirstName { get; }

	protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
	{
		yield return FirstName;
		yield return LastName;
	}

	public override string ToString()
	{
		string result =
			$"{FirstName?.Value} {LastName?.Value}".Trim();

		return result;
	}
}
