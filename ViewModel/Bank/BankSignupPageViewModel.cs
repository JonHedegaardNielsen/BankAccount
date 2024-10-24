
namespace BankAccount;

public class BankSignupPageViewModel : SignUpViewModel
{

	public BankSignupPageViewModel(object? currentPage) : base(currentPage)
	{
	}

	protected override void CreateUser()
	{
		BankUserDatabase.Instance.CreateUser(Username, Password);

	}
}
