using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для AutorizationPage.xaml
	/// </summary>
	public partial class AutorizationPage : Page
	{
		public AutorizationPage()
		{
			InitializeComponent();
		}

		private void UserEnter(object sender, MouseButtonEventArgs e)
		{
			// Поиск аккаунта
			Accounts account = StorageClass.DB.Accounts.FirstOrDefault(x =>
				x.Email.ToLower() == IEmail.Text.ToLower() && x.Password == IPassword.Password);

			if (account == null)
				MessageBox.Show("Пользователь не найден");
			else
			{
				// пользователь найден
				// инициализация переменной для имя и отчества пользователя
				String Name = "";
				try
				{
					// Разбитие ФИО на слова
					string[] strings = account.Users.FIO.Split(new char[] { ' ' });

					// Составление приветствия
					Name = strings[1] + " ";
					if (strings.Length > 2)
						Name += strings[2];
					MessageBox.Show("Приветствуем вас, " + Name);
				}
				catch
				{
					// если не получилось сформировать приветствие
					MessageBox.Show("Приветствуем вас");
				}

				// проверка роли и переход на нужную страницу
				switch (account.Users.Roles.Role)
				{
					case "Организатор":
						StorageClass.MainFrame.Navigate(new OrganizerPage(Name, account.Users));
						break;
					case "Участник":
						StorageClass.MainFrame.Navigate(new ParticipantPage(Name, account.Users));
						break;
					case "Жюри":
						StorageClass.MainFrame.Navigate(new JuriPage(Name, account.Users));
						break;
					case "Модератор":
						StorageClass.MainFrame.Navigate(new ModeratorPage(Name, account.Users));
						break;
				}
			}
		}

		private void GuestEnter(object sender, MouseButtonEventArgs e)
		{
			StorageClass.MainFrame.Navigate(new ParticipantPage(null, null));
        }
	}
}
