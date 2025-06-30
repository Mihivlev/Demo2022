using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для ModeratorActivityPage.xaml
	/// </summary>
	public partial class ModeratorActivityPage : Page
	{
		Users user { get; set; }
		public ModeratorActivityPage(Users moderator)
		{
			InitializeComponent();
			user = moderator;
			LVActivity.ItemsSource = StorageClass.DB.Activities.ToList().Where(x => x.ModeratorID == user.ID);
		}

		private void AddActivity(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new StatementPage(null, user));
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			LVActivity.ItemsSource = StorageClass.DB.Activities.ToList()
				.Where(x => x.ModeratorID == user.ID && x.Activity.Contains(SearchText.Text));
		}
	}
}
