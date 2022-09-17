namespace UserManagements.Domain.SharedKernel;

public class Text : SeedWork.ValueObject
{
	public static CustomResult.Result<Text>
		Create(string value, int minimumLength, int maximumLength, string caption)
	{
		var result =
			new CustomResult.Result<Text>();

		value =
			Framework.Utility.String.Text.Fix(value: value);

		if (value is null)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}

		if (minimumLength > 0)
		{
			if (value.Length < minimumLength)
			{
				var errorMessage = string.Empty;

				result.WithError
					(errorMessage: errorMessage);

				return result;
			}
		}

		if (maximumLength > 0)
		{
			if (value.Length > maximumLength)
			{
				var errorMessage = string.Empty;

				result.WithError
					(errorMessage: errorMessage);

				return result;
			}
		}

		var returnValue =
			new Text(value: value);

		result.WithValue(value: returnValue);

		return result;
	}
	protected Text() : base()
	{
	}

	protected Text(string value) : this()
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
