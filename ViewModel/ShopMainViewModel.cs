using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BankAccount;

class ShopMainViewModel : INotifyPropertyChanged
{


	public event PropertyChangedEventHandler PropertyChanged;

	public decimal balance
	{
		get => ShopUser.CurrentShopUser.UserBankAccount.Balance;
		set
		{
			if(ShopUser.CurrentShopUser.UserBankAccount.Balance != value)
			{
				ShopUser.CurrentShopUser.UserBankAccount.Balance = value;
				OnPropertyChanged(nameof(balance));
			}
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
