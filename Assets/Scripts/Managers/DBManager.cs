using UnityEngine;

public static class DBManager
{
	public static string useremail;

	public static bool LoggedIn { get { return useremail != null; } }

	//public static string inGameName;

	//public static int score;

	//public static int highScore;

	public static void LogOut()
	{
		useremail = null;
		//UpdateHighScore(highScore);
	}

	//public static int UpdateHighScore(int highscore)
	//{		
	//	if(score > highscore)
	//	{
	//		return score;
	//	}
	//	else
	//	{
	//		return highscore;
	//	}

	//}
}
