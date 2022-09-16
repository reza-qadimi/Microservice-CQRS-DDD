using UserManagements.Domain.Aggregates.Users;

namespace UserManagements.Persistence.EF.Aggregates.Users;

internal class UserConfiguration :
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<User>
{
	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata.Builders
		.EntityTypeBuilder<User> builder)
	{
	}
}
