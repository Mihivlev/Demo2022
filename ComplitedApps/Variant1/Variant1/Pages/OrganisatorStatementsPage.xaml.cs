using System.Linq;
using System.Windows.Controls;
using Variant1.Classes;
using System.Windows;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для OrganisatorStatementsPage.xaml
	/// </summary>
	public partial class OrganisatorStatementsPage : Page
	{
		Users user;
		public OrganisatorStatementsPage(Users selectedUser)
		{
			InitializeComponent();
			user = selectedUser;
			LVStatement.ItemsSource = StorageClass.DB.Statements.ToList();
		}

		private void ToStatement(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			Statements statement = border.DataContext as Statements;
			StorageClass.UserFrame.Navigate(new StatementPage(statement, user));
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			// Список заявлений, наименование которых содержит текст поисковой строки
			LVStatement.ItemsSource = StorageClass.DB.Statements.ToList()
				.Where(x => x.Activities.Activity.Contains(SearchText.Text));
		}

		private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			// Если данная страница сейчас просматривается
			if (Visibility == Visibility.Visible)
				// Обновить все данные
				StorageClass.DB.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
			// Список заявлений, наименование которых содержит текст поисковой строки
			LVStatement.ItemsSource = StorageClass.DB.Statements.ToList()
				.Where(x => x.Activities.Activity.Contains(SearchText.Text));
		}
	}
}