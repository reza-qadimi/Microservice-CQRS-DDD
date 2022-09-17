namespace UserManagements.Domain.Aggregates.Users.ValueObjects;

public class Username : SeedWork.ValueObject
{
	#region Constant(s)
	public const int MinLength = 8;

	public const int MaxLength = 20;

	public const string RegularExpression = "^[a-zA-Z0-9_-]{8,20}$";
	#endregion /Constant(s)

	#region Static Member(s)
	public static CustomResult.Result<Username> Create(string value)
	{
		var result =
			new CustomResult.Result<Username>();

		value =
			Framework.Utility.String
			.Text.Fix(value: value);

		if (value is null)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}

		if (value.Length < MinLength)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}

		if (value.Length > MaxLength)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}

		if (System.Text.RegularExpressions.Regex.IsMatch
			(input: value, pattern: RegularExpression) == false)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}

		var returnValue =
			new Username(value: value);

		result.WithValue
			(value: returnValue);

		return result;
	}
	#endregion /Static Member(s)

	private Username() : base()
	{
	}

	private Username(string value) : this()
	{
		Value = value;
	}

	public string Value { get; }

	protected override
		System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}

	public override string ToString()
	{
		return Value;
	}
}
