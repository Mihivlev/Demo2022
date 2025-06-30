using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>  
	/// Логика взаимодействия для ModeratorStatementsPage.xaml
	/// </summary>
	public partial class ModeratorStatementsPage : Page
	{
		Users user;
		public ModeratorStatementsPage(Users mainUser)
		{
			InitializeComponent();
			user = mainUser;
			LVStatement.ItemsSource = StorageClass.DB.Statements.ToList().Where(x => x.Activities.ModeratorID == user.ID);
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			LVStatement.ItemsSource = StorageClass.DB.Statements.ToList()
				.Where(x => x.Activities.Activity.Contains(SearchText.Text) && x.Activities.ModeratorID == user.ID);
		}

		private void AddStatement(object sender, MouseButtonEventArgs e)
		{
			StorageClass.UserFrame.Navigate(new StatementPage(null, user));
        }

		private void ToStatement(object sender, MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			Statements statement = border.DataContext as Statements;
			StorageClass.UserFrame.Navigate(statement, user);
		}
	}
}
