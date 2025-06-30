using System;
using System.IO;

namespace Variant1.Classes
{
	public partial class Events
	{
		public byte[] Photo
		{
			get
			{
				string way = AppDomain.CurrentDomain.BaseDirectory.ToString()
					.Replace("bin\\Debug\\", "") + "Resources/logo.png";
				if (PhotoSource != null)
					return PhotoSource;
				else
					return File.ReadAllBytes(way);
			}
		}
		public string Connect { get; set; }
	}
}
