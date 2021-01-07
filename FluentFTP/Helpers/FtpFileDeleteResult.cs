using System;
using System.Collections.Generic;
using System.Text;

namespace FluentFTP.Helpers
{
	/// <summary>
	/// TODO:
	/// </summary>
	public class FtpFileDeleteResult : FtpResult {

		public override string ToString()
		{
			var sb = new StringBuilder();

			// add type
			if (IsFailed)
			{
				sb.Append("Failed delete: ");
			}
			else
			{
				sb.Append("Delete:        ");
			}

			// add path
			if (RemotePath != null)
			{
				sb.Append("remote file ");
				sb.Append(RemotePath);
			}
			else
			{
				sb.Append("local file ");
				sb.Append(RemotePath);
			}

			// add error
			if (IsFailed && Exception != null && Exception.Message != null)
			{
				sb.Append("  [!]  ");
				sb.Append(Exception.Message);
			}

			return sb.ToString();
		}
	}
}
