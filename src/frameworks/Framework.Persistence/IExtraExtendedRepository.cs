using Framework.Domain;

namespace Framework.Persistence;

public interface IExtraExtendedRepository<TDomain, TKey> :
	IExtendedRepository<TDomain, TKey>, IExtendedQueryRepository<TDomain, TKey>
	where TDomain : Entity<TKey>
{
}
