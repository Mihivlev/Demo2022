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
	/// Логика взаимодействия для RegistrPage.xaml
	/// </summary>
	public partial class RegistrPage : Page
	{
		Users user = new Users();
		Accounts account = new Accounts();
		public RegistrPage()
		{
			InitializeComponent();
			CBCountries.ItemsSource = StorageClass.DB.Countries.ToList();

			DataContext = user;
			TBEmail.DataContext = account;
			TBPassword.DataContext = account;
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
				user.RoleID = 1;
				StorageClass.DB.Users.Add(user);
				StorageClass.DB.SaveChanges();

				TBID.Text = Convert.ToString(user.ID);

				if (account.ID == 0)
				{
					account.UserID = user.ID;
					account.Password = TBPassword.Text;
					StorageClass.DB.Accounts.Add(account);
					StorageClass.DB.SaveChanges();
				}
				
				MessageBox.Show("Вы успешно зарегистрированы");

				String Name = "";
				try
				{
					string[] strings = account.Users.FIO.Split(new char[] { ' ' });

					Name = strings[1] + " ";
					if (strings.Length > 2)
						Name += strings[2];
				}
				catch{}

				StorageClass.MainFrame.Navigate(new ParticipantPage(Name, user));
			}
		}
	}
}
