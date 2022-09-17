using UserManagements.Domain.SharedKernel;

namespace UserManagements.Domain.Aggregates.Users.ValueObjects;

public class Id : SeedWork.ValueObject
{
	#region Static Member(s)
	public static CustomResult.Result<Id> Create(System.Guid? value)
	{
		var result =
			new CustomResult.Result<Id>();

		if (value.HasValue == false)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}

		if (value == System.Guid.Empty)
		{
			var errorMessage = string.Empty;

			result.WithError
				(errorMessage: errorMessage);

			return result;
		}

		var returnValue =
			new Id(value: value.Value);

		result.WithValue(value: returnValue);

		return result;
	}
	#endregion /Static Member(s)


	private Id() : base()
	{
	}

	private Id(System.Guid value) : this()
	{
		Value = value;
	}

	public System.Guid Value { get; }

	protected override
		System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
	{
		yield return Value;
	}

	public override string ToString()
	{
		return Value.ToString();
	}
}
