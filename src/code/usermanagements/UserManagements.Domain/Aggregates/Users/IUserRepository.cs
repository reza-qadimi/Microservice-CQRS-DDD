namespace UserManagements.Domain.Aggregates.Users;

public interface IUserRepository :
	Framework.Persistence.IRepository<User, Domain.Aggregates.Users.ValueObjects.Id>
{
	System.Threading.Tasks.Task
		CreateUser(User user);

	System.Threading.Tasks.Task
		<bool>
		IsUsernameRepetitive(string username);
}
