using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class CasinoLoginViewmodel : ReactiveObject
{
	public ReactiveCommand<Tuple<string, string>, Unit> LoginCommand { get; set; }
	private Action OnLoginSucces;
	private Action OnLoginFailed;
	private Func<Tuple<string, string>> OnLoginSetParam;
	private object CurrentPage;

    public CasinoLoginViewmodel( object currentPage)
    {
		CurrentPage = currentPage;
		LoginCommand = ReactiveCommand.Create<Tuple<string, string>>(Login);
    }

    public void Login(Tuple<string, string> parameter)
	{
		//parameter = OnLoginSetParam();

		//CasinoUser.CurrentUser = CasinoUserDatabase.Instance.FindUser(parameter.Item1, parameter.Item2);
		//if (CasinoUser.CurrentUser != null)
		//	OnLoginSucces();
		//else
		//	OnLoginFailed();
		
	}
}
