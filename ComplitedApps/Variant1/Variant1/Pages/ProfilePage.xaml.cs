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
	/// Логика взаимодействия для ProfilePage.xaml
	/// </summary>
	public partial class ProfilePage : Page
	{
		Users user;
		Accounts account;
		public ProfilePage(Users selectedUser)
		{
			InitializeComponent();
			user = selectedUser;

			// Поиск аккаунта по ID пользователя
			account = StorageClass.DB.Accounts.FirstOrDefault(x => x.UserID == user.ID);

			DataContext = user;
			TBEmail.DataContext = account;

			// Элемента для ComboBox
			CBCountry.ItemsSource = StorageClass.DB.Countries.ToList();
		}

		private void SwitchGender(object sender, MouseButtonEventArgs e)
		{
			// Если у пользователя женский пол
			if (user.GenderID == 1)
				user.GenderID = 2;
			// Во всех других случаях (даже если пол не установлен)
			else
				user.GenderID = 1;
			// Передача в TextBlock информации о поле пользователя
			TBGender.Text = user.Genders.Gender;
		}

		private void ChangePhoto(object sender, MouseButtonEventArgs e)
		{
			// Создание обзора
			OpenFileDialog dialog = new OpenFileDialog();
			// Фильтр для обзора
			dialog.Filter = "Image |*.png; *.jpg; *.jpeg;";
			// Открытие обзора
			if (dialog.ShowDialog() == true)
			{
				// Помещение фото в элемент img
				Photo.Source = new BitmapImage(new Uri(dialog.FileName));
				// Преобразование выбраного фото в двоичные данные
				user.PhotoSource = File.ReadAllBytes(dialog.FileName);
			}
		}

		private void ChangePassword(object sender, MouseButtonEventArgs e)
		{
			// Если пароля и повторение пароля одинакови и не пусты
			if (TBNewPassword.Text == TBRepeatPassword.Text && !string.IsNullOrEmpty(TBNewPassword.Text))
			{
				// Прикрепление нового пароля
				account.Password = TBNewPassword.Text;
				MessageBox.Show("Новый пароль установлен. Не забудьте сохранить изменения");
			}
			else
				MessageBox.Show("Введите новый пароль и повторите его");
		}

		private void Save(object sender, MouseButtonEventArgs e)
		{
			// Создание конструктора текста
			StringBuilder errors = new StringBuilder();

			// Если блок ФИО пуст
			if (string.IsNullOrEmpty(TBFIO.Text))
				errors.AppendLine("Введите ФИО");

			// Если блок телефона пуст
			if (string.IsNullOrEmpty(TBPhone.Text))
				errors.AppendLine("Введите номер телефона");

			// Если блок почты пуст
			if (string.IsNullOrEmpty(TBEmail.Text))
				errors.AppendLine("Введите email");

			// Создание списка акккаунта
			List<Accounts> accounts = StorageClass.DB.Accounts.ToList();
			// Цикл для перебора аккаунтов
			for (int i = 0; i < accounts.Count(); i++)
				// Используется ли почта другими пользователями
				if (accounts[i].Email.ToLower() == TBEmail.Text.ToLower() && accounts[i].UserID != user.ID)
					errors.AppendLine("Данный email уже используется, введите другую почту");

			// Если в конструкторе текста присутствует текст
			if (errors.Length > 0)
				MessageBox.Show(errors.ToString());
			else
			{
				StorageClass.DB.SaveChanges();
				MessageBox.Show("Изменения сохранены");
			}
		}
	}
}
