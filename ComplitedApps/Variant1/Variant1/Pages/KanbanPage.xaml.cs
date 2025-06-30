using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для KanbanPage.xaml
	/// </summary>
	public partial class KanbanPage : Page
	{
		public KanbanPage(Events events)
		{
			InitializeComponent();
			DataContext = events;

			//Если нет активностей, то показть TextBlock
			if (events.Activities.Count == 0)
				AboutList.Visibility = Visibility.Visible;
		}

		private void GoBack(object sender, MouseButtonEventArgs e)
		{
			NavigationService.GoBack();
		}
	}
}
