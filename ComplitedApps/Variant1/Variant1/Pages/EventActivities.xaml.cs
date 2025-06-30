using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для EventActivities.xaml
	/// </summary>
	public partial class EventActivities : Page
	{ 
		Events events;
		public EventActivities(Events selectedEvent)
		{
			InitializeComponent();
			events = selectedEvent;
			LoadData();
		}

		private void LoadData()
		{
			// Очистка списка от элементов
			LVActivities.Items.Clear();

			foreach (var item in StorageClass.DB.Activities)
			{
				// Если мероприятия содержит эту активность
				if (events.Activities.Contains(item))
					item.Connect = "Убрать";
				else
					item.Connect = "Добавить";

				// Добавить элемент в список
				LVActivities.Items.Add(item);
			}
		}

		private void GoBack(object sender, MouseButtonEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void ChangeActivityStatus(object sender, MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			Activities activitiy = border.DataContext as Activities;

			if (events.Activities.Contains(activitiy))
				// Убрать активность из мероприятия
				events.Activities.Remove(activitiy);
			else
				// Добавить активность в мероприятия
				events.Activities.Add(activitiy);

			StorageClass.DB.SaveChanges();
			// Обновить список
			LoadData();
		}
	}
}
