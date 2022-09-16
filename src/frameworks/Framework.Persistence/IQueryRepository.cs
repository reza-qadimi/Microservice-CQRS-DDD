using Framework.Domain;

namespace Framework.Persistence;

public interface IQueryRepository<TDomain, TKey> where TDomain : Entity<TKey>
{
}
