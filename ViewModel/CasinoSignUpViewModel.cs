using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BankAccount;

public class CasinoSignUpViewModel : ViewModel
{
	public ObservableCollection<BankAccount> BankAccounts;
	
	private BankAccount _selectedBankAccount;
	public BankAccount SelectedBankAccount
	{
		get => _selectedBankAccount;
		set
		{
			if (_selectedBankAccount != value)
			{
				_selectedBankAccount = value;
				OnPropertyChanged(nameof(SelectedBankAccount));
			}
		}
	}

    public CasinoSignUpViewModel()
    {
		BankAccounts = new(BankUser.CurrentUser.BankAccounts);
	}
}
