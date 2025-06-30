using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для SimpleListEventPage.xaml
	/// </summary>
	public partial class SimpleListEventPage : Page
	{
		Users user;
		public SimpleListEventPage(Users selectedUser)
		{
			InitializeComponent();
			user = selectedUser;

			List<Directions> ListDirections = StorageClass.DB.Directions.ToList();
			ListDirections.Insert(0, new Directions { ID = 0, Direction = "Все направления" });
			CBDirections.ItemsSource = ListDirections;

			LoadEvents();
		}

		private void LoadEvents()
		{
			LVEvents.Items.Clear();
			if (string.IsNullOrEmpty(DPForList.Text))
			{
				if (CBDirections.SelectedIndex != 0)
				{
					Directions direction = CBDirections.SelectedItem as Directions;
					foreach (var item in StorageClass.DB.Events)
					{
						if (item.DirectionID == direction.ID)
						{
							if (item.Users.Contains(user))
								item.Connect = "Не участвовать";
							else
								item.Connect = "Добавиться";
							LVEvents.Items.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in StorageClass.DB.Events)
					{
						if (item.Users.Contains(user))
							item.Connect = "Не участвовать";
						else
							item.Connect = "Добавиться";
						LVEvents.Items.Add(item);
					}
				}
            }
			else
			{
				DateTime selectedDate = DateTime.Parse(DPForList.Text);
				if (CBDirections.SelectedIndex != 0)
				{
					Directions direction = CBDirections.SelectedItem as Directions;
					foreach (var item in StorageClass.DB.Events)
					{
						if (item.DirectionID == direction.ID && item.Date == selectedDate)
						{
							if (item.Users.Contains(user))
								item.Connect = "Не участвовать";
							else
								item.Connect = "Добавиться";
							LVEvents.Items.Add(item);
						}
					}
				}
				else
				{
					foreach (var item in StorageClass.DB.Events)
					{
						if (item.Users.Contains(user))
							item.Connect = "Не участвовать";
						else
							item.Connect = "Добавиться";
						LVEvents.Items.Add(item);
					}
				}
			}
		}

		private void SelectDirection(object sender, SelectionChangedEventArgs e)
		{
			LoadEvents();
		}

		private void SelectDate(object sender, SelectionChangedEventArgs e)
		{
			LoadEvents();
		}

		private void AddUser(object sender, MouseButtonEventArgs e)
		{
			if (user != null)
			{
				Border border = sender as Border;
				Events Event = border.DataContext as Events;
				if (Event.Users.Contains(user))
				{
					MessageBoxResult result = MessageBox.Show("Вы действительно хотите отказаться от участия в этом мероприятии",
						   "Открепление пользователя от мероприятия", MessageBoxButton.YesNo, MessageBoxImage.Question);
					if (result == MessageBoxResult.Yes)
					{
						Event.Users.Remove(user);
						StorageClass.DB.SaveChanges();
						LoadEvents();
					}
				}
				else
				{
					MessageBoxResult result = MessageBox.Show("Вы действительно хотите участвовать в этом мероприятии",
						   "Прикрепление пользователя к мероприятию", MessageBoxButton.YesNo, MessageBoxImage.Question);
					if (result == MessageBoxResult.Yes)
					{
						Event.Users.Add(user);
						StorageClass.DB.SaveChanges();
						LoadEvents();
					}
				}
			}
			else
			{
				MessageBoxResult result = MessageBox.Show("Чтобы участвовать в мероприятии, необходимо зарегистрироваться. \nПерейти к регистрации?",
					   "Прикрепление пользователя к мероприятию", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
					StorageClass.MainFrame.Navigate(new RegistrPage());
			}
		}
	}
}