using System;
using System.IO;

namespace Variant1.Classes
{
	public partial class Users
	{
		// Для отображения фото
		public byte[] Photo {
			get
			{
				string way = AppDomain.CurrentDomain.BaseDirectory.ToString()
					.Replace("bin\\Debug\\","") + "Resources/logo.png";
				if (PhotoSource != null)
					return PhotoSource;
				else
					return File.ReadAllBytes(way);
			}
		}
		public string Connect { get; set; }
		public string Email {
			get
			{
				foreach (var item in StorageClass.DB.Accounts)
				{
					if (item.UserID == ID)
						return item.Email;
				}
				return null;
			}
			set { }
		}
	}
}
