namespace UserManagements.Domain.SeedWork;

public abstract class AggregateRoot<TKey, TDomain> :
	Entity<TKey>, Framework.Domain.IAggregateRoot<TKey>
{
	public AggregateRoot() : base()
	{
		_domainEvents = new();
	}

	private readonly System.Collections.Generic.List
		<Framework.Domain.IDomainEvent<TKey>> _domainEvents;

	public void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

	public System.Collections.Generic.IReadOnlyList
		<Framework.Domain.IDomainEvent<TKey>> GetUncommittedEvents()
	{
		return _domainEvents;
	}

	protected void RaiseDomainEvent
		(Framework.Domain.IDomainEvent<TKey> domainEvent)
	{
		if (domainEvent == null)
		{
			return;
		}

		if (_domainEvents.Contains(item: domainEvent))
		{
			return;
		}

		_domainEvents.Add(item: domainEvent);
	}

	protected void RemoveDomainEvent
		(Framework.Domain.IDomainEvent<TKey> domainEvent)
	{
		if (domainEvent == null)
		{
			return;
		}

		if (_domainEvents.Contains(item: domainEvent))
		{
			_domainEvents.Remove(item: domainEvent);
		}
	}
}
