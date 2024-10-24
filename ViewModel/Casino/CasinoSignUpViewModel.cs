using ReactiveUI;

namespace BankAccount;

public class CasinoSignUpViewModel : SignUpViewModel
{
	private BankAccount? _selectedBankAccount;
	public BankAccount? SelectedBankAccount
	{
		get => _selectedBankAccount;
		set => this.RaiseAndSetIfChanged(ref _selectedBankAccount, value);
	}

	public CasinoSignUpViewModel(object? currentPage) : base(currentPage)
	{
		OnGoToLogin = () => BankUser.LogOut();
	}

	protected override void CreateUser()
	{
		if (_selectedBankAccount != null)
		{
			CasinoUserDatabase.Instance.CreateUser(Username, Password, _selectedBankAccount.Id);
			BankUser.LogOut();
		}
	}
}
