using ReactiveUI;

namespace BankAccount;

public class ShopSignUpViewModel : SignUpViewModel
{
    private BankAccount? _selectedBankAccount;
    public BankAccount? SelectedBankAccount
    {
        get => _selectedBankAccount;
        set => this.RaiseAndSetIfChanged(ref _selectedBankAccount, value);
    }

    public ShopSignUpViewModel(object? currentPage) : base(currentPage)
    {
        OnGoToLogin = () => BankUser.LogOut();
    }

	protected override void CreateUser()
	{
        if (_selectedBankAccount != null)
        {
			ShopUserDatabase.Instance.CreateUser(Username, Password, _selectedBankAccount.Id);
            SelectedBankAccount = null;
		}
	}
}
