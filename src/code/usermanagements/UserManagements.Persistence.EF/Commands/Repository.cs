namespace UserManagements.Persistence.EF.Commands;

public class Repository<TDomain, TKey> :
	object, IRepository<TDomain, TKey> where TDomain : Framework.Domain.Entity<TKey>
{
	internal Repository(DatabaseContext databaseContext) : base()
	{
		DatabaseContext =
			databaseContext ?? throw new System.ArgumentNullException(paramName: nameof(databaseContext));

		DbSet = DatabaseContext.Set<TDomain>();
	}

	internal DatabaseContext DatabaseContext { get; }

	internal Microsoft.EntityFrameworkCore.DbSet<TDomain> DbSet { get; }
}
