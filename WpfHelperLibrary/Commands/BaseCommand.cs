using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfHelperLibrary.Commands
{
	public abstract class BaseCommand : ICommand
	{

		/// <summary>
		/// Wire up command to the Commandmanager
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			//This is done to wire up to the WPF command center
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public abstract bool CanExecute(object parameter);

		public abstract void Execute(object parameter);
	}
}
