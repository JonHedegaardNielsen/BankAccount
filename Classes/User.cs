namespace BankAccount;

public abstract class User
{
	public int Id { get; protected set; }
	protected string Username = string.Empty;
	protected string Password = string.Empty;

    public User(int id, string username, string password)
    {
        Id = id;
        Username = username;
        Password = password;
    }

	protected static User ValidateGetUser(User? user)
    {
		if (user == null)
			throw new NotLoggedInException();

		return user;
	}
}
