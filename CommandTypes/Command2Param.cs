using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class Command2Param<T1, T2>
{
	private readonly Action<T1, T2> _execute;

	public Command2Param(Action<T1, T2> execute)
	{
		_execute = execute ?? throw new ArgumentNullException(nameof(execute));
	}

	public void Execute(T1 parameter1, T2 parameter2)
	{
		_execute(parameter1, parameter2);
	}
}
