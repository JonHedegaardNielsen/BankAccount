namespace BankAccount;

public interface ILoginDatabase
{
	public bool FindUser(string username, string password, out User? user);
}
