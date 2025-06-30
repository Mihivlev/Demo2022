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
	/// Логика взаимодействия для ListEventsPage.xaml
	/// </summary>
	public partial class ListEventsPage : Page
	{
		public ListEventsPage()
		{
			InitializeComponent();
			LVEvents.ItemsSource = StorageClass.DB.Events.ToList();

			List<Directions> ListDirections = StorageClass.DB.Directions.ToList();
			ListDirections.Insert(0, new Directions { ID = 0, Direction = "Все направления" });
			CBDirections.ItemsSource = ListDirections;
		}

		private void LoadEvents()
		{
			// Если поисковая строка пуста
			if (string.IsNullOrEmpty(DPForList.Text))
			{
				// Если индекс ComboBox равен 0 (выбрано "Все направления")
				if (CBDirections.SelectedIndex != 0)
				{
					Directions direction = CBDirections.SelectedItem as Directions;
					LVEvents.ItemsSource = StorageClass.DB.Events.ToList().Where(x => x.DirectionID == direction.ID);
				}
				else
					LVEvents.ItemsSource = StorageClass.DB.Events.ToList();
			}
			// Если поисковая строка не пуста
			else
			{
				DateTime selectedDate = DateTime.Parse(DPForList.Text);
				if (CBDirections.SelectedIndex != 0)
				{
					Directions direction = CBDirections.SelectedItem as Directions;
					LVEvents.ItemsSource = StorageClass.DB.Events.ToList()
						.Where(x => x.DirectionID == direction.ID && x.Date == selectedDate);
				}
				else
					LVEvents.ItemsSource = StorageClass.DB.Events.ToList().Where(x => x.Date == selectedDate);
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

		private void ToEvent(object sender, MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			Events events = border.DataContext as Events;
			StorageClass.UserFrame.Navigate(new EventPage(events));
		}

		private void AddEvent(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new EventPage(null));
		}

		private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (Visibility == Visibility.Visible)
				StorageClass.DB.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
			LoadEvents();
		}
	}
}
