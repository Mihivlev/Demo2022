using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для EventJury.xaml
	/// </summary>
	public partial class EventJury : Page
	{
		Events events;
		public EventJury(Events selectedEvent)
		{
			InitializeComponent();
			DataContext = events = selectedEvent;
			LoadData();
		}

		private void LoadData()
		{
			LVJury.Items.Clear();

			foreach (var item in StorageClass.DB.Users.Where(x => x.Roles.Role == "Жюри"))
			{
				if (events.Users.Contains(item))
					item.Connect = "Убрать";
				else
					item.Connect = "Добавить";

				LVJury.Items.Add(item);
			}
		}

		private void GoBack(object sender, MouseButtonEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void ChangeJuryStatus(object sender, MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			Activities activitiy = border.DataContext as Activities;

			if (events.Activities.Contains(activitiy))
				events.Activities.Remove(activitiy);
			else
				events.Activities.Add(activitiy);

			StorageClass.DB.SaveChanges();
			LoadData();
		}
	}
}
