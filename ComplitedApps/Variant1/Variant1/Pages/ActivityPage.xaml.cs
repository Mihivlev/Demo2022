using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для ActivityPage.xaml
	/// </summary>
	public partial class ActivityPage : Page
	{
		Activities activity = new Activities();
		public ActivityPage(Activities selectedActivity)
		{
			InitializeComponent();

			if (selectedActivity != null)
				activity = selectedActivity;

			DataContext = activity;

			CBModerators.ItemsSource = StorageClass.DB.Users.ToList().Where(x => x.Roles.Role == "Модератор");
			CBTimes.ItemsSource = StorageClass.DB.TimeForActivity.ToList();
		}

		private void Save(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			StringBuilder errors = new StringBuilder();

			if (string.IsNullOrEmpty(IName.Text))
				errors.AppendLine("Введите название");

			if (CBModerators.SelectedIndex == -1)
				errors.AppendLine("Выберите модератора");

			if (CBModerators.SelectedIndex == -1)
				errors.AppendLine("Выберите время начала");

			if (errors.Length > 0)
				MessageBox.Show(errors.ToString());
			else
			{
				if (activity.ID == 0)
					StorageClass.DB.Activities.Add(activity);
				StorageClass.DB.SaveChanges();
				MessageBox.Show("Информация сохранена");
			}
		}

		private void Delete(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (activity.ID == 0)
				NavigationService.GoBack();
			else
			{
				MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить эту активность",
					"Удаление активности", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					StorageClass.DB.Activities.Remove(activity);
					StorageClass.DB.SaveChanges();
					NavigationService.GoBack();
				}
			}
		}
	}
}
