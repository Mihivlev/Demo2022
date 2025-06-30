using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для JuriDirectionsPage.xaml
	/// </summary>
	public partial class JuriDirectionsPage : Page
	{
		Users user;
		public JuriDirectionsPage(Users SelectedUser)
		{
			InitializeComponent();
			DataContext = user = SelectedUser;
			LoadData();
		}

		private void LoadData()
		{
			LVDirections.Items.Clear();

			foreach (var item in StorageClass.DB.Directions)
			{
				if (user.Directions.Contains(item))
					item.Connect = "Убрать";
				else
					item.Connect = "Добавить";

				LVDirections.Items.Add(item);
			}
		}

		private void ChangeDirection(object sender, MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			Directions direction = border.DataContext as Directions;

			if (user.Directions.Contains(direction))
				user.Directions.Remove(direction);
			else
				user.Directions.Add(direction);

			StorageClass.DB.SaveChanges();
			LoadData();
		}

		private void GoBack(object sender, MouseButtonEventArgs e)
		{
			NavigationService.GoBack();
		}
	}
}
