namespace UserManagements.Domain.Aggregates.Users.ValueObjects;

public enum UserType : byte
{
	User = 0,
	Admin = 1,
	Owner = 2,
	Programmer = 3,
}
