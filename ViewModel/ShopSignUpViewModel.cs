using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

class ShopSignUpViewModel : ReactiveObject
{
	private object? _currentPage;
	public object? CurrentPage
	{
		get => _currentPage;
		set => this.RaiseAndSetIfChanged(ref _currentPage, value);
	}

}
