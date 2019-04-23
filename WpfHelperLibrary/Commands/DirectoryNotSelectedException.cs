using System;
using System.Runtime.Serialization;

namespace WpfHelperLibrary.Commands
{
	[Serializable]
	public class DirectoryNotSelectedException : Exception
	{
		public DirectoryNotSelectedException()
		{
		}

		public DirectoryNotSelectedException(string message) : base(message)
		{
		}

		public DirectoryNotSelectedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected DirectoryNotSelectedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}