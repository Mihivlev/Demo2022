namespace Variant1.Classes
{
	public partial class Activities
	{
		public string Connect {get;set;}
		public string Status
		{
			get
			{
				if (IsApproved == true)
					return "Одобрено";
				else
					return "Не одобрено";
			}
			set { }
		}
	}
}
