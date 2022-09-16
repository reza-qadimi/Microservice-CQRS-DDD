using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserManagements.Domain.Aggregates.Users;

namespace UserManagements.Persistence.EF.Aggregates.Users;

public class UserRepository :
	Commands.Repository<User, System.Guid>, IUserRepository
{
	internal UserRepository(DatabaseContext databaseContext) : base(databaseContext: databaseContext)
	{
	}

	public async
		System.Threading.Tasks.Task
		CreateUser
		(User user)
	{
		if (user == null)
		{
			throw new System.ArgumentNullException(paramName: nameof(user));
		}

		await DbSet.AddAsync(user);
	}

	public async
		System.Threading.Tasks.Task<bool>
		IsUsernameRepetitive(string username)
	{
		if (string.IsNullOrWhiteSpace(value: username))
		{
			throw new System.ArgumentNullException(paramName: nameof(username));
		}

		var foundAny =
			await DbSet
			.Where(current => current.Username.ToLower() == username.ToLower())
			.AnyAsync();

		return foundAny;
	}
}
