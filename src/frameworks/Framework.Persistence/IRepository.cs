using Framework.Domain;

namespace Framework.Persistence;

public interface IRepository<TDomain, TKey> :
	IQueryRepository<TDomain, TKey> where TDomain : Entity<TKey>
{
}
