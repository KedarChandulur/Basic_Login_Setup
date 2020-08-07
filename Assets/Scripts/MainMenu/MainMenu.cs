using UnityEngine;
using UnityEngine.UI;
//using Kedar.RichText;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Text usermailDisplay; 
	[SerializeField] private Button registerButton, loginButton,startGameButton;
	void Start()
	{
		//print("Welcome to Main Menu".Bold().Color("Red").Size(25));
		//print("Press Register Button to register".Italic().Color("Black").Size(11));
		//print("Press Login Button to login ".Italic().Color("White").Size(11));

		if(DBManager.LoggedIn)
		{
			usermailDisplay.text = "User logged in as: " + DBManager.useremail;
		}

		registerButton.onClick.AddListener(GoToRegister);
		loginButton.onClick.AddListener(GoToLogin);
		//startGameButton.onClick.AddListener(GoToLauncherScene);
	}

	private void GoToRegister()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("RegisterMenu");
	}

	private void GoToLogin()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("LoginMenu");
	}

	private void GoToLauncherScene()
	{
		if (!DBManager.LoggedIn)
		{
			usermailDisplay.text = "Login First to Start the Game";
		}
		else
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Launcher");
		}
	}
}
