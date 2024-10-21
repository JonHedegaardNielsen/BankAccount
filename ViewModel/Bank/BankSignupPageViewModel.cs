using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

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
