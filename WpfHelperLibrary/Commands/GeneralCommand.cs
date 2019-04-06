using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfHelperLibrary.Commands
{
	/// <summary>
	/// Command wich delegates the calls
	/// </summary>
	public class GeneralCommand : ICommand
	{
		#region [ Fields ]

		/// <summary>
		/// If the command can be executed
		/// </summary>
		private Func<object, bool> canExecute;

		/// <summary>
		/// The execution of the command
		/// </summary>
		private Action<object> execute;

		#endregion

		#region [ Constructors ]

		/// <summary>
		/// 
		/// </summary>
		/// <param name="canExecute">Function determinig if the command can be executed</param>
		/// <param name="execute">Action that executes the command</param>
		/// <exception cref="ArgumentNullException"/>
		public GeneralCommand(Func<object, bool> canExecute, Action<object> execute)
		{
			if (canExecute == null || execute == null)
				throw new ArgumentNullException();

			this.canExecute = canExecute;
			this.execute = execute;
		}

		#endregion

		#region [ ICommand Members ]

		/// <summary>
		/// Wire up command to the Commandmanager
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			//This is done to wire up to the WPF command center
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		virtual public bool CanExecute(object parameter)
		{
			return canExecute(parameter);
		}

		virtual public void Execute(object parameter)
		{
			execute(parameter);
		}

		#endregion
	}
}
