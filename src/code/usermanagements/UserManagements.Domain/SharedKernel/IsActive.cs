namespace UserManagements.Domain.SharedKernel;

public class IsActive : SeedWork.ValueObject
{
	#region Static Member(s)
	public static CustomResult.Result<IsActive> Create(bool? value)
	{
		var result =
			new CustomResult.Result<IsActive>();

		if (value.HasValue == false)
		{
			value = false;
		}

		var returnValue =
			new IsActive(value: value.Value);

		result.WithValue
			(value: returnValue);

		return result;
	}
	#endregion /Static Member(s)

	private IsActive() : base()
	{
	}

	private IsActive(bool value) : this()
	{
		Value = value;
	}

	public bool Value { get; }

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
