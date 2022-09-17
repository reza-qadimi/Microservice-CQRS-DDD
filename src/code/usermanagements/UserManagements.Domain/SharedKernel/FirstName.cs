using System.Resources;

namespace UserManagements.Domain.SharedKernel;

public class FirstName : SeedWork.ValueObject
{
	#region Constant(s)
	public const int MaxLength = 50;
	#endregion /Constant(s)

	#region Static Member(s)
	public static CustomResult.Result<FirstName> Create(string value)
	{
		var result =
			new CustomResult.Result<FirstName>();

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

		if (value.Length > MaxLength)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}

		var returnValue =
			new FirstName(value: value);

		result.WithValue(value: returnValue);

		return result;
	}
	#endregion /Static Member(s)

	private FirstName() : base()
	{
	}

	private FirstName(string value) : this()
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
		if (string.IsNullOrWhiteSpace(Value))
		{
			return "-".PadLeft(totalWidth: 5, paddingChar: '-');
		}
		else
		{
			return Value;
		}
	}
}
