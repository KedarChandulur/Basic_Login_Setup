using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Text usermailDisplay;
	private Text loginText, startGame,logoutText; 
	[SerializeField] private Button registerButton, loginButton,startGameButton,logoutButton;
	void Start()
	{
		loginText = loginButton.GetComponentInChildren<Text>();
		startGame = startGameButton.GetComponentInChildren<Text>();
		logoutText = logoutButton.GetComponentInChildren<Text>();

		if (DBManager.LoggedIn)
		{
			usermailDisplay.text = "User logged in as: " + DBManager.email;
			loginText.text = "You are LoggedIn";
			startGame.text = "Start Multiplayer.";
			logoutText.text = "Logout";
		}
		else
		{
			usermailDisplay.text = "User logged in as: " + DBManager.email;
			loginText.text = "Log in";
			startGame.text = "Start Game as Guest";
			logoutText.text = "You are not LoggedIn";
		}

		registerButton.onClick.AddListener(GoToRegister);
		loginButton.onClick.AddListener(GoToLogin);
		startGameButton.onClick.AddListener(GoToLauncherScene);
		logoutButton.onClick.AddListener(LogOut);
		
		registerButton.interactable = !DBManager.LoggedIn;
		loginButton.interactable = !DBManager.LoggedIn;
		logoutButton.interactable = DBManager.LoggedIn;
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
		UnityEngine.SceneManagement.SceneManager.LoadScene("Launcher");
	}

	private void LogOut()
	{
		if (DBManager.LoggedIn)
		{
			DBManager.LogOut();
			UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
		}
	}
}
