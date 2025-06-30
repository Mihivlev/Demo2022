using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для ListJuryPage.xaml
	/// </summary>
	public partial class ListJuryPage : Page
	{
		public ListJuryPage()
		{
			InitializeComponent();
			Search();

			CBEvents.Items.Add(new Events() { Event = "Любое мероприятие" });
            foreach (var item in StorageClass.DB.Events)
				CBEvents.Items.Add(item);
        }

		private void ToUser(object sender, MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			Users user = border.DataContext as Users;
			StorageClass.UserFrame.Navigate(new UserPage(user, ""));
		}

		private void AddUser(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new UserPage(null, ""));
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			Search();
        }

		private void CBEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Search();
		}

		private void Search()
		{
			if (CBEvents.SelectedIndex > 0)
				LVJury.ItemsSource = StorageClass.DB.Users.ToList().Where(x =>
									(x.Roles.Role == "Модератор" || x.Roles.Role == "Жюри")
									&& x.FIO.ToUpper().Contains(SearchText.Text.ToUpper())
									&& x.Events.Contains(CBEvents.SelectedItem));
			else
				LVJury.ItemsSource = StorageClass.DB.Users.ToList().Where(x =>
									(x.Roles.Role == "Модератор" || x.Roles.Role == "Жюри")
									&& x.FIO.ToUpper().Contains(SearchText.Text.ToUpper()));
		}

		private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (Visibility == Visibility.Visible)
				StorageClass.DB.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
			Search();
        }
	}
}
