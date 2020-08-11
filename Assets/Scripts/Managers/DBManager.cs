
public static class DBManager
{
	public static string username;

	public static string email;

	public static int playerCurrentScore;

	public static int playerHighScore;

	public static bool LoggedIn { get { return email != null; } }

	public static bool NameLoggedIn { get { return username != null; } }

	public static void LogOut()
	{
		username = null;
		email = null;

		//UpdateHighScore(highScore);
	}

	public static int UpdateHighScore()
	{
		if (playerCurrentScore > playerHighScore)
		{
			return playerCurrentScore;
		}
		else
		{
			return playerHighScore;
		}
	}
}
