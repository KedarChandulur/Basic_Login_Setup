using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	//Might need SerializeField.
	private Text usermailDisplay;
	private Button registerButton, loginButton,startGameButton,logoutButton;
	//No need of SerializeField.
	private Text loginText, startGame,logoutText;

	void Start()
	{
		usermailDisplay = transform.GetChild(0).GetComponent<Text>();
		registerButton = transform.GetChild(1).GetComponent<Button>();
		loginButton = transform.GetChild(2).GetComponent<Button>();
		startGameButton = transform.GetChild(3).GetComponent<Button>();
		logoutButton = transform.GetChild(4).GetComponent<Button>();

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
		Debug.LogError("No Scene name given.", this);
		Debug.Log("Logged in as: " + DBManager.email, this);
		//UnityEngine.SceneManagement.SceneManager.LoadScene("MyScene");
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
