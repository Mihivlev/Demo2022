using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для OrganizerPage.xaml
	/// </summary>
	public partial class OrganizerPage : Page
	{
		Users user;
		public OrganizerPage(string Name, Users organizer)
		{
			InitializeComponent();
			// Контекст страницы (от него зависят binding)
			DataContext = user = organizer;

			// Помещение фрейма пользователя в глобальную переменную
			StorageClass.UserFrame = UserFrame;

			// Определение времения для приветствия
			DateTime date = DateTime.Now;
			if (date.Hour > 5 && date.Hour < 11)
				HelloTime.Text = "Доброго утра";
			else if (date.Hour > 10 && date.Hour < 18)
				HelloTime.Text = "Добрый день";
			else if (date.Hour > 17 && date.Hour < 6)
				HelloTime.Text = "Доброго вечера";

			// Определение пола пользователя
			if (user.GenderID == 1)
				HelloName.Text = "Мисс " + Name;
			else
				HelloName.Text = "Мистер " + Name;
		}

		private void Profile(object sender, MouseButtonEventArgs e)
		{
			UserFrame.Navigate(new ProfilePage(user));
        }

		private void Statements(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new OrganisatorStatementsPage(user));
        }

		private void Activity(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new ListActivities());
		}

		private void Events(object sender, MouseButtonEventArgs e)
		{
			UserFrame.Navigate(new ListEventsPage());
		}

		private void Participants(object sender, MouseButtonEventArgs e)
		{
			UserFrame.Navigate(new ListParticipantsPage());
		}

		private void Jury(object sender, MouseButtonEventArgs e)
		{
			UserFrame.Navigate(new ListJuryPage());
		}

		private void AccountExit(object sender, MouseButtonEventArgs e)
		{
			// Сообщение с вопросом о выходе из аккаунта
			MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти из аккаунта?",
				"Выход из аккаунта", MessageBoxButton.YesNo, MessageBoxImage.Question);
			// Ответ "да"
			if (result == MessageBoxResult.Yes)
				StorageClass.MainFrame.Navigate(new AutorizationPage());
		}

		private void CloseApp(object sender, MouseButtonEventArgs e)
		{
			// Сообщение с вопросом о выходе из приложения
			MessageBoxResult result = MessageBox.Show("Вы действительно хотите закрыть приложение?",
				"Закрытие приложения", MessageBoxButton.YesNo, MessageBoxImage.Question);
			// Ответ "да"
			if (result == MessageBoxResult.Yes) 
				StorageClass.window.Close();
		}
    }
}
