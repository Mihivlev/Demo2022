using System.Windows;
using System.Windows.Controls;

namespace Variant1.Classes
{
	internal class StorageClass
	{
		public static Frame MainFrame { get; set; }
		public static Frame UserFrame { get; set; }
		public static DB_Demo2022Entities DB = new DB_Demo2022Entities();
		public static Window window { get; set; }
	}
}
