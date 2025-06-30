using Microsoft.Win32;
using System;
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
	/// Логика взаимодействия для EventPage.xaml
	/// </summary>
	public partial class EventPage : Page
	{
		Events CurrentEvent = new Events();
		public EventPage(Events SelectedEvent)
		{
			InitializeComponent();

			if (SelectedEvent != null)
			{
				CurrentEvent = SelectedEvent;
				TBName.Text = SelectedEvent.Event;
				btnCancel.Text = "Удалить";
				// Показать кнопку перехода к активностям мероприятия
				SPEventActivity.Visibility = Visibility.Visible;
			}

			DataContext = CurrentEvent;
			CBCities.ItemsSource = StorageClass.DB.Cities.ToList();
			CBDirections.ItemsSource = StorageClass.DB.Directions.ToList();
		}

		private void Save(object sender, MouseButtonEventArgs e)
		{
			StringBuilder errors = new StringBuilder();

			if (string.IsNullOrEmpty(IName.Text))
				errors.AppendLine("Введите наименование");

			if (string.IsNullOrEmpty(IDays.Text))
				errors.AppendLine("Введите кол-во дней");

			if (Convert.ToInt16(IDays.Text) < 1)
				errors.AppendLine("Кол-во дней должно быть больше нуля");

			if (CBDirections.SelectedIndex == -1)
				errors.AppendLine("Выберите направление");

			if (CBDirections.SelectedIndex == -1)
				errors.AppendLine("Выберите город проведения");

			if (errors.Length > 0)
				MessageBox.Show(errors.ToString());
			else
			{
				if (CurrentEvent.ID == 0)
				{
					StorageClass.DB.Events.Add(CurrentEvent);
				}
				StorageClass.DB.SaveChanges();
				TBName.Text = CurrentEvent.Event;
				btnCancel.Text = "Удалить";
				SPEventActivity.Visibility = Visibility.Visible;
				MessageBox.Show("Информация сохранена");
			}
		}

		private void Delete(object sender, MouseButtonEventArgs e)
		{
			if (CurrentEvent.ID == 0)
				StorageClass.UserFrame.Navigate(new ListEventsPage());
			else
			{
				MessageBoxResult result = MessageBox.Show("Вы действительно хоитите удалить мероприятие ",
					   "Удаление мероприятия", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					StorageClass.DB.Events.Remove(CurrentEvent);
					StorageClass.DB.SaveChanges();
					StorageClass.UserFrame.Navigate(new ListEventsPage());
				}
			}
		}

		private void ChangePhoto(object sender, MouseButtonEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Image |*.png; *.jpg; *.jpeg;";
			if (dialog.ShowDialog() == true)
			{
				Photo.Source = new BitmapImage(new Uri(dialog.FileName));
				CurrentEvent.PhotoSource = File.ReadAllBytes(dialog.FileName);
			}
		}

		private void ToKanban(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new KanbanPage(CurrentEvent));
		}

		private void ToActivities(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new EventActivities(CurrentEvent));
		}

		private void ToJury(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new EventJury(CurrentEvent));
		}
	}
}
