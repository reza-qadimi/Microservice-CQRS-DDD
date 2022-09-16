namespace UserManagements.Persistence.EF.Commands;

public interface IRepository<TDomain, TKey> :
	Framework.Persistence.IRepository<TDomain, TKey> where TDomain : Framework.Domain.Entity<TKey>
{
}
