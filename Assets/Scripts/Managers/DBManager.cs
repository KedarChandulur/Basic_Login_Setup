
public static class DBManager
{
	public static string username;

	public static string email;

	public static int playerCurrentScore;

	public static int playerHighScore;

	public static bool LoggedInWithEmail { get { return email != null; } }

	public static bool GetUserName { get { return username != null; } }

	public static void LogOutfromEmailandName()
	{
		LogOutfromEmail();
		LogOutfromUserName();

		//UpdateHighScore(highScore);
	}

	public static void LogOutfromEmail()
	{
		email = null;

		//UpdateHighScore(highScore);
	}

	public static void LogOutfromUserName()
	{
		username = null;

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
