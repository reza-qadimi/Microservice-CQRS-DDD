using UserManagements.Domain.Aggregates.Users;

namespace UserManagements.Persistence.EF.Aggregates.Users;

public interface IUserRepository :
	Commands.IRepository<User, System.Guid>
{
	System.Threading.Tasks.Task
		CreateUser
		(User user);

	System.Threading.Tasks.Task
		<bool>
		IsUsernameRepetitive(string username);
}
