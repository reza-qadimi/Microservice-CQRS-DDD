using System.Linq;

namespace UserManagements.Domain.SeedWork;

/// <summary>
/// https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
/// </summary>
public abstract class ValueObject : object
{
	public static bool operator ==(ValueObject leftObject, ValueObject rightObject)
	{
		var result = EqualOperator(leftObject, rightObject);

		return result;
	}

	protected static bool EqualOperator(ValueObject leftObject, ValueObject rightObject)
	{
		if (leftObject is null && rightObject is null)
		{
			return true;
		}

		if (leftObject is null && rightObject is not null)
		{
			return false;
		}

		if (leftObject is not null && rightObject is null)
		{
			return false;
		}

		//if (ReferenceEquals(objA: left, objB: null) ^ ReferenceEquals(objA: right, objB: null))
		//{
		//	return false;
		//}

		//return ReferenceEquals(left, right) || left.Equals(right);

		var result =
			leftObject.Equals(rightObject);

		return result;
	}

	public static bool operator !=(ValueObject leftObject, ValueObject rightObject)
	{
		var result =
			NotEqualOperator(leftObject, rightObject);

		return result;
	}

	protected static bool NotEqualOperator(ValueObject left, ValueObject right)
	{
		return !(EqualOperator(left, right));
	}

	protected ValueObject() : base()
	{
	}

	protected abstract System.Collections.Generic.IEnumerable<object> GetEqualityComponents();

	public override bool Equals(object otherObject)
	{
		if (otherObject == null || otherObject.GetType() != GetType())
		{
			return false;
		}

		var other =
			otherObject as ValueObject;

		var result =
			GetEqualityComponents()
			.SequenceEqual(second: other.GetEqualityComponents());

		return result;
	}

	public override int GetHashCode()
	{
		var result =
			GetEqualityComponents()
			.Select(x => x != null ? x.GetHashCode() : 0)
			.Aggregate((x, y) => x ^ y);

		return result;
	}
}
