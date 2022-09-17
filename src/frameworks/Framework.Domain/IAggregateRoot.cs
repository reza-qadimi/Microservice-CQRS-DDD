namespace Framework.Domain;

public interface IAggregateRoot<TKey> : IEntity<TKey>
{
	void ClearDomainEvents();

	//System.Collections.Generic.IReadOnlyList
	//	<IDomainEvent<TKey>> DomainEvents { get; }

	System.Collections.Generic.IReadOnlyList
		<IDomainEvent<TKey>> GetUncommittedEvents();
}
