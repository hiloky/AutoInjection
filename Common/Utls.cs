using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    public class Utls
    {
		private static readonly IConfiguration _configuration;

		static Utls()
		{
			string text = "appsettings.json";
			string text2 = AppContext.BaseDirectory;
			text2 = text2.Replace("\\", "/");
			string text3 = text2 + "/" + text;
			if (!File.Exists(text3))
			{
				int num = text2.IndexOf("/bin");
				text3 = text2.Substring(0, num) + "/" + text;
			}
			Utls._configuration = JsonConfigurationExtensions.AddJsonFile(new ConfigurationBuilder(), text3, optional: false, reloadOnChange: true).Build();
		}

		/// <summary>
		/// 根据key获取配置值
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetSectionValue(string key)
		{
			string result;
			try
			{
				IConfigurationSection section = Utls._configuration.GetSection(key);
				result = (ConfigurationExtensions.Exists(section) ? section.Value : string.Empty);
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}
	}
}
