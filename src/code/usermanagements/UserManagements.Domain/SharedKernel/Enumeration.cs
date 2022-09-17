namespace UserManagements.Domain.SharedKernel;

public class Enumeration : SeedWork.Enumeration
{
	#region Static Member(s)
	internal
		static
		CustomResult.Result<TValue> GetByValue<TValue>
		(int? value, string name) where TValue : SeedWork.Enumeration
	{
		var result =
			new CustomResult.Result<TValue>();

		// **************************************************
		if (value is null)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}
		// **************************************************

		// **************************************************
		var enumValue =
			FromValue<TValue>(value: value.Value);

		if (enumValue is null)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}
		// **************************************************

		result.WithValue(value: enumValue);

		return result;
	}
	#endregion /Static Member(s)

	protected Enumeration() : base()
	{
	}

	protected Enumeration(int value, string name) : base(value: value, name: name)
	{
	}
}
