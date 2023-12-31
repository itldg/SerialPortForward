/// <summary>
/// 类说明：Assistant
/// 编 码 人：苏飞
/// 联系方式：361983679  
/// 更新网站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DotNet.Utilities
{
	/// <summary>
	/// INI文件读写类。
	/// </summary>
	public class INIFileHelper
	{
		public string path;

		public INIFileHelper(string INIPath)
		{
			path = INIPath;
		}

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);


		/// <summary>
		/// 写INI文件
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Key"></param>
		/// <param name="Value"></param>
		public void IniWriteValue(string Section, string Key, string Value)
		{
			WritePrivateProfileString(Section, Key, Value, this.path);
		}

		/// <summary>
		/// 读取INI文件
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Key"></param>
		/// <returns></returns>
		public string IniReadValue(string Section, string Key, object defaultstr)
		{
			StringBuilder temp = new StringBuilder(2000);
			int i = GetPrivateProfileString(Section, Key, "", temp, 2000, this.path);
			if (string.IsNullOrEmpty(temp.ToString()))
			{
				return defaultstr.ToString();
			}
			return temp.ToString();
		}
		public byte[] IniReadValues(string section, string key)
		{
			byte[] temp = new byte[255];
			int i = GetPrivateProfileString(section, key, "", temp, 255, this.path);
			return temp;

		}


		/// <summary>
		/// 删除ini文件下所有段落
		/// </summary>
		public void ClearAllSection()
		{
			IniWriteValue(null, null, null);
		}
		/// <summary>
		/// 删除ini文件下personal段落下的所有键
		/// </summary>
		/// <param name="Section"></param>
		public void ClearSection(string Section)
		{
			IniWriteValue(Section, null, null);
		}

	}


}
