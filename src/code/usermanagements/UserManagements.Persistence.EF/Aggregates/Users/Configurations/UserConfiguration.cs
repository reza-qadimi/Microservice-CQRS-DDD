using UserManagements.Domain.Aggregates.Users;

namespace UserManagements.Persistence.EF.Aggregates.Users.Configurations;

internal class UserConfiguration :
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<User>
{
	public UserConfiguration() : base()
	{
	}

	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata.Builders
		.EntityTypeBuilder<User> builder)
	{
	}
}
