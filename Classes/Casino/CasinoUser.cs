
namespace BankAccount;

class CasinoUser : User
{
	private static CasinoUser? _currentUser;
	public static CasinoUser CurrentUser
	{
		get => (CasinoUser)ValidateGetUser(_currentUser);
	}

	public decimal AmountToWinBack { get; set; }

	public BankAccount BankAccount { get; }

	public static bool Login(string? userName, string? password)
	{
		if (userName != null && password != null)

		if (CasinoUserDatabase.Instance.FindUser(userName, password, out User? shopuser))
			_currentUser = (CasinoUser?)shopuser;

		return _currentUser != null;
	}

	public static void Logout() =>
		_currentUser = null;

	public CasinoUser(int id, string username, string password, BankAccount bankAccount, decimal amountToWinBack) : base(id, username, password)
    {
		BankAccount = bankAccount;
		AmountToWinBack = amountToWinBack;
    }
}
