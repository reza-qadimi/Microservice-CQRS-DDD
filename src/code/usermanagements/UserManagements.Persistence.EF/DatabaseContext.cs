using UserManagements.Persistence.EF.Aggregates.Users.Configurations;

namespace UserManagements.Persistence.EF;

internal class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
	public DatabaseContext
		(Microsoft.EntityFrameworkCore.DbContextOptions
		<DatabaseContext> options) : base(options)
	{
	}

	protected override void
		OnModelCreating
		(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(typeof(UserConfiguration).Assembly);
	}
}
