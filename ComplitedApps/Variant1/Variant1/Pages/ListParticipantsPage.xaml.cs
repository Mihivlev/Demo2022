using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для ListParticipantsPage.xaml
	/// </summary>
	public partial class ListParticipantsPage : Page
	{
		public ListParticipantsPage()
		{
			InitializeComponent();
			
			LVParticipants.ItemsSource = StorageClass.DB.Users.ToList()
				.Where(x => x.Roles.Role == "Участник");
			
			CBEvents.Items.Add(new Events() { Event = "Все мероприятия" });
			List<Events> events = StorageClass.DB.Events.ToList();

			for (int i = events.Count-1; i >= 0; i--)
				CBEvents.Items.Add(events[i]);
        }

		private void AddParticipants(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new UserPage(null, "Участник"));
		}

		private void ToParticipant(object sender, MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			Users user = border.DataContext as Users;
			StorageClass.UserFrame.Navigate(new UserPage(user, "Участник"));
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
				LVParticipants.ItemsSource = StorageClass.DB.Users.ToList().Where(x => 
											 x.Roles.Role == "Участник"
											 && x.FIO.ToUpper().Contains(SearchText.Text.ToUpper())
											 && x.Events.Contains(CBEvents.SelectedItem));
			else
				LVParticipants.ItemsSource = StorageClass.DB.Users.ToList().Where(x =>
											 x.Roles.Role == "Участник"
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
