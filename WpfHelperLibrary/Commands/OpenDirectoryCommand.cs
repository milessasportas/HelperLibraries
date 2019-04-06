﻿using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfHelperLibrary.Commands
{
	/// <summary>
	/// Prompts the user to welect a directory, selected directory can be accessed via the <see cref="SelectedDirectory"/> property.
	/// </summary>
	/// <remarks>
	/// Only supports Windows Vista an onwards
	/// </remarks>
	public class OpenDirectoryCommand : ICommand
	{
		public OpenDirectoryCommand()
		{

		}


		/// <exception cref="DirectoryNotSelectedException"/>
		public string Execute()
		{
			try
			{
				Execute(null);
				return SelectedDirectory;
			}
			catch (DirectoryNotSelectedException)
			{
				throw;
			}
		}


		void ICommand.Execute(object parameter)
			=> Execute(parameter as string);

		/// <summary>
		/// Displays the select folder Dialog to the user
		/// </summary>
		/// <exception cref="DirectoryNotSelectedException"/>
		public void Execute(string startingDirectory)
		{
			//check if supported
			if (CommonFileDialog.IsPlatformSupported)
			{
				//generate the folder picker
				var dialog = new CommonOpenFileDialog();
				dialog.IsFolderPicker = true;

				//set default directory is passed
				if (startingDirectory is string)
					dialog.DefaultDirectory = startingDirectory as string;

				//show dialofg and acrt on result
				if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
					SelectedDirectory = dialog.FileName;
				else
				{
					SelectedDirectory = null;
					throw new DirectoryNotSelectedException();
				}
			}
			else
				throw new InvalidOperationException("Only supported in Windows Vista an onwards");
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		private string selDirectory;

		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// Returns the Directory wich is selected
		/// </summary>
		/// <exception cref="DirectoryNotSelectedException"/>
		public string SelectedDirectory
		{
			get
			{
				if (SelectedDirectory == null)
					throw new DirectoryNotSelectedException($"Directory not set, call {nameof(Execute)}");

				return selDirectory;
			}
			set
			{
				selDirectory = value;
			}
		}

	}
}