using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для ListActivities.xaml
	/// </summary>
	public partial class ListActivities : Page
	{
		public ListActivities()
		{
			InitializeComponent();
			// Список одобренных активностей
			LVActivity.ItemsSource = StorageClass.DB.Activities.ToList().Where(x => x.IsApproved == true);

			// Создание класса для 0 индекса ComboBox
			CBModerators.Items.Add(new Users() { FIO = "Любой модератор" });
			// Заполнение ComboBox
            foreach (var item in StorageClass.DB.Users.ToList().Where(x => x.Roles.Role == "Модератор"))
				CBModerators.Items.Add(item);
        }

		private void AddActivity(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new ActivityPage(null));
        }

		private void ToActivity(object sender, MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			Activities activity = border.DataContext as Activities;
			StorageClass.UserFrame.Navigate(new ActivityPage(activity));
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			Search();
		}

		private void CBEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Search();
		}

		private void Search()
		{
			// Если индекс выбранного элемента больше 0 (выбрали не 1 элемент списка)
			if (CBModerators.SelectedIndex > 0)
				// Список активностей, наименование которых содержит текст поисковой строки
				// и выбранный модератор это модератор этой активности
				LVActivity.ItemsSource = StorageClass.DB.Activities.ToList().Where(x =>
											x.Activity.ToUpper().Contains(SearchText.Text.ToUpper())
											&& x.Users == CBModerators.SelectedItem
											&& x.IsApproved == true);
			else
				// Список активностей наименование которых содержит текст поисковой строки
				LVActivity.ItemsSource = StorageClass.DB.Activities.ToList().Where(x =>
											x.Activity.ToUpper().Contains(SearchText.Text.ToUpper())
											&& x.IsApproved == true);
		}

		private void Page_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
		{
			if (Visibility == Visibility.Visible)
				StorageClass.DB.ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
			Search();
		}
	}
}
