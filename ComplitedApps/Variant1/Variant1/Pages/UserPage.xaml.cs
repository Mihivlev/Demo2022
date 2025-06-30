using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для UserPage.xaml
	/// </summary>
	public partial class UserPage : Page
	{
		Users user = new Users();
		Accounts account = new Accounts();
		public UserPage(Users SelectedUser, string role)
		{
			InitializeComponent();
			CBCountries.ItemsSource = StorageClass.DB.Countries.ToList();

			if (SelectedUser != null)
			{
				user = SelectedUser;
				TBID.Text = Convert.ToString(user.ID);

				if (user.Roles.Role != "Участник")
					btnToDirections.Visibility = Visibility.Visible;
				foreach (Accounts item in StorageClass.DB.Accounts)
					if (item.UserID == user.ID)
						account = item;
			}

			DataContext = user;
			TBEmail.DataContext = account;
			TBPassword.DataContext = account;

			if (role == "Участник")
			{
				TBHeader.Text = "Регистрация участника";
				user.Roles = StorageClass.DB.Roles.FirstOrDefault(x => x.Role == "Участник");
				TBRole.Text = "Участник";
				btnRole.Visibility = Visibility.Hidden;
			}
			else
				TBHeader.Text = "Регистрация жюри / модератора";
		}

		private void SwitchGender(object sender, MouseButtonEventArgs e)
		{
			if (user.GenderID == 1)
			{
				user.GenderID = 2;
				TBGender.Text = "Мужской";
			}
			else
			{
				user.GenderID = 1;
				TBGender.Text = "Женский";
			}
		}

		private void SwitchRole(object sender, MouseButtonEventArgs e)
		{
			if (user.RoleID == 2)
			{
				user.RoleID = 3;
				TBRole.Text = "Модератор";
			}
			else
			{
				user.RoleID = 2;
				TBRole.Text = "Жюри";
			}
		}

		private void ToDirections(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new JuriDirectionsPage(user));
		}

		private void ChangePhoto(object sender, MouseButtonEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Image |*.png; *.jpg; *.jpeg;";
			if (dialog.ShowDialog() == true)
				Photo.Source = new BitmapImage(new Uri(dialog.FileName));

			user.PhotoSource = File.ReadAllBytes(dialog.FileName);
		}

		private void Save(object sender, MouseButtonEventArgs e)
		{
			StringBuilder errors = new StringBuilder();

			if (String.IsNullOrEmpty(TBFIO.Text))
				errors.AppendLine("Введите ФИО");

			if (String.IsNullOrEmpty(TBGender.Text))
				errors.AppendLine("Выберите пол");

			if (String.IsNullOrEmpty(TBRole.Text))
				errors.AppendLine("Выберите роль");

			if (String.IsNullOrEmpty(TBPhone.Text))
				errors.AppendLine("Введите номер телефона");

			if (CBCountries.SelectedIndex == -1)
				errors.AppendLine("Выберите страну");

			if (String.IsNullOrEmpty(TBEmail.Text))
				errors.AppendLine("Введите email");

			else
			{
				List<Accounts> accounts = StorageClass.DB.Accounts.ToList();
				for (int i = 0; i < accounts.Count(); i++)
				{
					if (user.ID == 0)
						if (accounts[i].Email.ToLower() == TBEmail.Text.ToLower())
							errors.AppendLine("Данный email уже используется, введите другую почту");
					else
						if (accounts[i].Email.ToLower() == TBEmail.Text.ToLower() && accounts[i].UserID != user.ID)
							errors.AppendLine("Данный email уже используется, введите другую почту");
				}
			}

			if (String.IsNullOrEmpty(TBPassword.Text))
				errors.AppendLine("Введите пароль");

			if (errors.Length > 0)
				MessageBox.Show(errors.ToString());
			else
			{
				if (user.Roles.Role != "Участник")
					btnToDirections.Visibility = Visibility.Visible;

				if (user.ID == 0)
					StorageClass.DB.Users.Add(user);

				account.UserID = user.ID;
				account.Password = TBPassword.Text;

				StorageClass.DB.SaveChanges();
				TBID.Text = Convert.ToString(user.ID);

				if (account.ID == 0)
				{
					StorageClass.DB.Accounts.Add(account);
					StorageClass.DB.SaveChanges();
				}

				MessageBox.Show("Информация о пользователе сохранена");
			}
		}

		private void Delete(object sender, MouseButtonEventArgs e)
		{
			if (user.ID == 0)
				NavigationService.GoBack();
			else
			{
				MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этого пользователя",
					"Удаление пользователя", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					StorageClass.DB.Users.Remove(user);
					StorageClass.DB.SaveChanges();
					NavigationService.GoBack();
				}
			}
		}
	}
}
