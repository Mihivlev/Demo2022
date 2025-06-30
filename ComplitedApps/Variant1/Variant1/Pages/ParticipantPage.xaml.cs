using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для ParticipantPage.xaml
	/// </summary>
	public partial class ParticipantPage : Page
	{
		Users user;
		public ParticipantPage(string Name, Users participant)
		{
			InitializeComponent();
			StorageClass.UserFrame = UserFrame;

			DateTime date = DateTime.Now;
			if (date.Hour > 5 && date.Hour < 11)
				HelloTime.Text = "Доброго утра";
			else if (date.Hour > 10 && date.Hour < 18)
				HelloTime.Text = "Добрый день";
			else if (date.Hour > 17 && date.Hour < 6)
				HelloTime.Text = "Доброго вечера";

			if (participant != null)
			{
				DataContext = user = participant;
				TBRole.Text = "Участник";

				if (user.GenderID == 1)
					HelloName.Text = "Мисс " + Name;
				else
					HelloName.Text = "Мистер " + Name;
			}
			else
			{
				HelloName.Text = "Гость";
				TBRole.Text = "Гость";
			}
		}

		private void Profile(object sender, MouseButtonEventArgs e)
		{
			UserFrame.Navigate(new ProfilePage(user));
		}
		private void Events(object sender, MouseButtonEventArgs e)
		{
			UserFrame.Navigate(new SimpleListEventPage(user));
		}

		private void AccountExit(object sender, MouseButtonEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти из аккаунта?",
				"Выход из аккаунта", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
				StorageClass.MainFrame.Navigate(new AutorizationPage());
		}

		private void CloseApp(object sender, MouseButtonEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Закрыть приложение?", "Закрытие",
				MessageBoxButton.OKCancel, MessageBoxImage.Question);
			if (result == MessageBoxResult.OK)
				StorageClass.window.Close();
		}
	}
}