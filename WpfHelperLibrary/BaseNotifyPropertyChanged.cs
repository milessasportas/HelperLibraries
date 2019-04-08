using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHelperLibrary
{
	/// <summary>
	/// Base class wich implements the INotifyPropertyChanged event
	/// </summary>
	public abstract class BaseNotifyPropertyChanged : INotifyPropertyChanged
	{
		#region [ INotifyPropertyChanged Members ]

		/// <summary>
		/// Gets Raised when a Property gets changed
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises the PropertyChanged event
		/// </summary>
		/// <param name="propertyName">The name of the property that was changed</param>
		protected void RaisePropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion [ INotifyPropertyChanged Members ]
	}
}
