using Microsoft.EntityFrameworkCore;

namespace UserManagements.Persistence.EF.Aggregates.Users.Configurations;

internal class UserConfiguration :
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Aggregates.Users.User>
{
	public UserConfiguration() : base()
	{
	}

	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata
		.Builders.EntityTypeBuilder<Domain.Aggregates.Users.User> builder)
	{
		// **************************************************
		builder
			.HasKey(p => p.Id)
			.IsClustered(clustered: true)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(p => p.Id)
			.IsRequired(required: true)
			.HasConversion(p => p.Value,
				p => Domain.Aggregates.Users.ValueObjects.Id.Create(p).Value)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(p => p.Username)
			.HasMaxLength(maxLength: Domain.Aggregates.Users.ValueObjects.Username.MaxLength)
			.IsRequired(required: true)
			.HasConversion(p => p.Value,
				p => Domain.Aggregates.Users.ValueObjects.Username.Create(p).Value)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(p => p.Password)
			.HasMaxLength(maxLength: Domain.Aggregates.Users.ValueObjects.Password.LengthInDatabase)
			.IsRequired(required: true)
			.HasConversion(p => p.Value,
				p => Domain.Aggregates.Users.ValueObjects.Password.CreateWithoutHashing(p).Value)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(p => p.IsActive)
			.IsRequired(required: true)
			.HasConversion(p => p.Value,
				p => Domain.SharedKernel.IsActive.Create(p).Value)
			;
		// **************************************************

		// **************************************************
		builder
			.HasOne(p => p.Role)
			.WithMany()
			.HasForeignKey(foreignKeyPropertyNames:
				nameof(Domain.Aggregates.Users.User.Role) + nameof(Domain.SeedWork.Entity<dynamic>.Id))
			.IsRequired(required: true)
			;

		builder
			.Property<int>(propertyName:
				nameof(Domain.Aggregates.Users.User.Role) + nameof(Domain.SeedWork.Entity<dynamic>.Id))
			.HasColumnName(name:
				nameof(Domain.Aggregates.Users.User.Role) + nameof(Domain.SeedWork.Entity<dynamic>.Id))
			.IsRequired(required: true)
			.UsePropertyAccessMode(propertyAccessMode:
				Microsoft.EntityFrameworkCore.PropertyAccessMode.Field)
			;
		// **************************************************

		// **************************************************
		builder
			.OwnsOne(p => p.FullName, p =>
			{
				// **************************************************
				p.Property<int>("GenderId")
					.HasColumnName(name: "GenderId")
					.IsRequired(required: true)
					.UsePropertyAccessMode(propertyAccessMode:
						Microsoft.EntityFrameworkCore.PropertyAccessMode.Field)
					;
				// **************************************************

				// **************************************************
				p.Property(pp => pp.FirstName)
					.IsRequired(required: true)
					.UsePropertyAccessMode(propertyAccessMode:
						Microsoft.EntityFrameworkCore.PropertyAccessMode.Field)
					.HasMaxLength(maxLength: Domain.SharedKernel.FirstName.MaxLength)
					.HasColumnName(name: nameof(Domain.SharedKernel.FullName.FirstName))
					.HasConversion(p => p.Value,
						p => Domain.SharedKernel.FirstName.Create(p).Value)
					;
				// **************************************************

				// **************************************************
				p.Property(pp => pp.LastName)
					.IsRequired(required: true)
					.UsePropertyAccessMode(propertyAccessMode:
						Microsoft.EntityFrameworkCore.PropertyAccessMode.Field)
					.HasMaxLength(maxLength: Domain.SharedKernel.LastName.MaxLength)
					.HasColumnName(name: nameof(Domain.SharedKernel.FullName.LastName))
					.HasConversion(p => p.Value,
						p => Domain.SharedKernel.LastName.Create(p).Value)
					;
				// **************************************************
			})
			.Navigation(p => p.FullName)
			.IsRequired(required: true)
			;
		// **************************************************




		// **************************************************
		builder
			.HasIndex
				(propertyNames: nameof(Domain.Aggregates.Users.User.Username))
			.IsUnique(unique: true)
			;
		// **************************************************
	}
}
