using System;
using System.Windows.Input;

public abstract class Command : ICommand
{
	protected readonly Func<object, bool> _canExecute;
	public event EventHandler CanExecuteChanged;

	public Command(Func<object, bool> canExecute = null)
	{
		_canExecute = canExecute;
	}
	
	public bool CanExecute(object parameter)
	{
		return _canExecute == null || _canExecute(parameter);
	}

	public virtual void Execute(object parameter)
	{

	}


	public void RaiseCanExecuteChanged()
	{
		CanExecuteChanged?.Invoke(this, EventArgs.Empty);
	}
}