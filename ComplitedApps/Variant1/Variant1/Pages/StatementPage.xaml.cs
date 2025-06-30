using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Variant1.Classes;

namespace Variant1.Pages
{
	/// <summary>
	/// Логика взаимодействия для StatementPage.xaml
	/// </summary>
	public partial class StatementPage : Page
	{
		Statements statement = new Statements();
		Activities activity = new Activities();
		public StatementPage(Statements selectedStatement, Users user)
		{
			InitializeComponent();
			CBTimes.ItemsSource = StorageClass.DB.TimeForActivity.ToList();

			if (user.Roles.Role == "Организатор")
				btnApprove.Visibility = Visibility.Visible;

			if (selectedStatement != null)
			{
				statement = selectedStatement;
				activity = statement.Activities;
			}
			else
			{
				statement.Activities = activity;
				activity.IsApproved = false;
				activity.ModeratorID = user.ID;
			}
			IDescription.DataContext = statement;
			DataContext = activity;
		}

		private void Save(object sender, MouseButtonEventArgs e) 
		{
			StringBuilder errors = new StringBuilder();
			if (string.IsNullOrEmpty(IName.Text))
				errors.AppendLine("Введите название");

			if (CBTimes.SelectedIndex == -1)
				errors.AppendLine("Выберите время начала");

			if (errors.Length > 0)
				MessageBox.Show(errors.ToString());
			else
			{
				if (statement.ID == 0)
				{
					StorageClass.DB.Activities.Add(activity);
					StorageClass.DB.Statements.Add(statement);
				}
				StorageClass.DB.SaveChanges();
				MessageBox.Show("Информация сохранена");
			}
        }

		private void Delete(object sender, MouseButtonEventArgs e)
		{
			if (statement.ID == 0)
				NavigationService.GoBack();
			else
			{
				MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить эту заявку",
					"Удаление заявки", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					StorageClass.DB.Activities.Remove(activity);
					StorageClass.DB.SaveChanges();
					MessageBox.Show("Зявка удалена","Удаление заявки");
				}
				NavigationService.GoBack();
			}
		}

		private void Approve(object sender, MouseButtonEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Вы действительно хотите одобрить эту заявку",
					"Одобрение заявки", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				StorageClass.DB.Statements.Remove(statement);
				activity.IsApproved = true;
				StorageClass.DB.SaveChanges();
			}
		}
	}
}
