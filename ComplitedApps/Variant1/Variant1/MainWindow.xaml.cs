using System.Windows;
using Variant1.Classes;
using Variant1.Pages;

namespace Variant1
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			StorageClass.MainFrame = MainFrame;
			StorageClass.window = this;
			StorageClass.MainFrame.Navigate(new AutorizationPage());
		}
	}
}
