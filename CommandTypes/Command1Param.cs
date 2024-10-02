using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class Command1Param<T> : Command
{
	private readonly Action<T> _execute;

	public Command1Param(Action<T> execute)
    {
		_execute = execute ?? throw new ArgumentNullException(nameof(execute));
	}

	public void Execute(T parameter)
	{
		_execute(parameter);
	}
}
