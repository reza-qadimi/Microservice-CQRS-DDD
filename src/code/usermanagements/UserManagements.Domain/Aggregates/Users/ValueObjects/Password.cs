using System.Resources;

namespace UserManagements.Domain.Aggregates.Users.ValueObjects;

public class Password : SeedWork.ValueObject
{
	#region Constant(s)
	public const int MinLength = 8;

	public const int MaxLength = 20;

	public const int LengthInDatabase = 40;

	public const string RegularExpression = "^[a-zA-Z0-9_-]{8,20}$";
	#endregion /Constant(s)

	#region Static Member(s)
	public static CustomResult.Result<Password> Create(string value)
	{
		var result =
			new CustomResult.Result<Password>();

		value =
			Framework.Utility.String
			.Text.Fix(value: value);

		if (value is null)
		{
			var errorMessage = string.Empty;

			result.WithError(errorMessage: errorMessage);

			return result;
		}

		if (value.Length < MinLength)
		{
			var errorMessage = string.Empty;

			result.WithError(errorMessage: errorMessage);

			return result;
		}

		if (value.Length > MaxLength)
		{
			var errorMessage = string.Empty;

			result.WithError(errorMessage: errorMessage);

			return result;
		}

		if (System.Text.RegularExpressions.Regex.IsMatch
			(input: value, pattern: RegularExpression) == false)
		{
			var errorMessage = string.Empty;

			result.WithError(errorMessage: errorMessage);

			return result;
		}

		string hashOfPassword =
			Framework.Utility.String.Cryptography
			.ComputeSha1Hash(value: value);

		var returnValue =
			new Password(value: hashOfPassword);

		result.WithValue(value: returnValue);

		return result;
	}

	public static CustomResult.Result<Password> CreateWithoutHashing(string value)
	{
		var result =
			new CustomResult.Result<Password>();

		value =
			value?.Trim();

		if (value is null)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}

		if (value.Length < LengthInDatabase)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);


			return result;
		}

		if (value.Length > LengthInDatabase)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);


			return result;
		}

		var returnValue =
			new Password(value: value);

		result.WithValue(value: returnValue);

		return result;
	}

	#endregion /Static Member(s)

	private Password() : base()
	{
	}

	private Password(string value) : this()
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
