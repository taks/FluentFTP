﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFTP {

	/// <summary>
	/// Stores the result of a file transfer when UploadDirectory or DownloadDirectory is used.
	/// </summary>
	public class FtpResult {

		/// <summary>
		/// Returns true if the file was downloaded, false if it was uploaded.
		/// </summary>
		public bool IsDownload { get; internal set; }

		/// <summary>
		/// Gets the type of file system object.
		/// </summary>
		public FtpFileSystemObjectType Type { get; internal set; }

		/// <summary>
		/// Gets the size of the file.
		/// </summary>
		public long Size { get; internal set; }

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
		/// Was the file skipped?
		/// </summary>
		public bool IsSkipped { get; internal set; }

		/// <summary>
		/// Was the file skipped due to failing the rule condition?
		/// </summary>
		public bool IsSkippedByRule { get; internal set; }

		/// <summary>
		/// Was there an error during transfer? You can read the Exception property for more details.
		/// </summary>
		public bool IsFailed { get; internal set; }

		/// <summary>
		/// Convert this result to a FTP list item.
		/// </summary>
		public FtpListItem ToListItem(bool useLocalPath) {
			return new FtpListItem {
				Type = Type,
				Size = Size,
				Name = Name,
				FullName = useLocalPath ? LocalPath : RemotePath,
			};
		}

		public override string ToString() {
			var sb = new StringBuilder();

			// add type
			if (IsSkipped) {
				sb.Append("Skipped:     ");
			}
			else if (IsFailed) {
				sb.Append("Failed:      ");
			}
			else {
				if (IsDownload) {
					sb.Append("Downloaded:  ");
				}
				else {
					sb.Append("Uploaded:    ");
				}
			}

			// add path
			if (IsDownload) {
				sb.Append(RemotePath);
				sb.Append("  -->  ");
				sb.Append(LocalPath);
			}
			else {
				sb.Append(LocalPath);
				sb.Append("  -->  ");
				sb.Append(RemotePath);
			}

			// add error
			if (IsFailed && Exception != null && Exception.Message != null) {
				sb.Append("  [!]  ");
				sb.Append(Exception.Message);
			}

			return sb.ToString();
		}

	}
}
