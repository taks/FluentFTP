using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFTP
{
	/// <summary>
	/// TODO:
	/// </summary>
	public class FtpResult {

		/// <summary>
		/// Gets the name and extension of the file.
		/// </summary>
		public string Name { get; internal set; }

		/// <summary>
		/// Stores the absolute remote path of the the current file being transfered.
		/// </summary>
		public string RemotePath { get; internal set; }

		/// <summary>
		/// Stores the absolute local path of the the current file being transfered.
		/// </summary>
		public string LocalPath { get; internal set; }

		/// <summary>
		/// Gets the error that occuring during transfering this file, if any.
		/// </summary>
		public Exception Exception { get; internal set; }

		/// <summary>
		/// Returns true if the file was downloaded/uploaded, or the file was already existing with the same file size.
		/// </summary>
		public bool IsSuccess { get; internal set; }

		/// <summary>
		/// Was there an error during transfer? You can read the Exception property for more details.
		/// </summary>
		public bool IsFailed { get; internal set; }
	}
}
