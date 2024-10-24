namespace BankAccount
{
	public class Login
	{
		public static bool CheckLength(string? text) =>
			text != null && text.Length >= 8 && text.Length <= 32;
	}


}
