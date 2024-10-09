using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class CasinoLoginViewmodel : ViewModel
{
	public Command1Param<Tuple<string, string>> LoginCommand { get; set; }
	private Action OnLoginSucces;
	private Action OnLoginFailed;
	private Func<Tuple<string, string>> OnLoginSetParam;
	private ContentControl MainContent;
    public CasinoLoginViewmodel(Action onLoginSucces, Action onLoginFailed, Func<Tuple<string, string>> onLoginSetParam, ContentControl mainContent)
    {
		MainContent = mainContent;
		LoginCommand = new Command1Param<Tuple<string, string>>(Login);
		OnLoginSucces = onLoginSucces;
		OnLoginFailed = onLoginFailed;
		OnLoginSetParam = onLoginSetParam;
    }

    public void Login(Tuple<string, string> parameter)
	{
		parameter = OnLoginSetParam();

		CasinoUser.CurrentUser = CasinoUserDatabase.Instance.FindUser(parameter.Item1, parameter.Item2);
		if (CasinoUser.CurrentUser != null)
			OnLoginSucces();
		else
			OnLoginFailed();
		
	}
}
