using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;

namespace BankAccount;

public class MainViewModel : ReactiveObject
{
	//private ReactiveObject _currentViewModel;
	//public ReactiveObject CurrentViewModel
	//{
	//	get => _currentViewModel;
	//	set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
	//}

	//public ReactiveCommand<Unit, Unit> ShowLoginPageCommand { get; set; }


	//public MainViewModel()
 //   {
 //       var loginPageViewModel = new LoginPageViewmodel();

	//	Unit ChangePageToLogin()
	//	{
	//		CurrentViewModel = loginPageViewModel;
	//		return Unit.Default;
	//	}

	//	ShowLoginPageCommand = ReactiveCommand.Create(ChangePageToLogin);
 //   }
}
