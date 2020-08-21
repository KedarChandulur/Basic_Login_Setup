using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	//Login and Logout Panels
	private GameObject loginPanel, logoutPanel;
	private Text usermailDisplay, loginTextviaEmail, startGame, logoutButtonText, loginTextviaName, logoutText;
	private Button registerButton, loginButtonviaEmail,startGameButton,logoutButton, loginButtonviaName,yesLogout,noDontLogout;

	void Start()
	{
		loginPanel = transform.GetChild(0).gameObject;
		logoutPanel = transform.GetChild(1).gameObject; ;

		loginPanel.SetActive(true);
		logoutPanel.SetActive(false);

		//References.
		usermailDisplay = loginPanel.transform.GetChild(0).GetComponent<Text>();
		registerButton = loginPanel.transform.GetChild(1).GetComponent<Button>();
		loginButtonviaEmail = loginPanel.transform.GetChild(2).GetComponent<Button>();
		startGameButton = loginPanel.transform.GetChild(3).GetComponent<Button>();
		logoutButton = loginPanel.transform.GetChild(4).GetComponent<Button>();
		loginButtonviaName = loginPanel.transform.GetChild(5).GetComponent<Button>();
		logoutText = logoutPanel.transform.GetChild(1).GetComponent<Text>();
		yesLogout = logoutPanel.transform.GetChild(2).GetComponent<Button>();
		noDontLogout = logoutPanel.transform.GetChild(3).GetComponent<Button>();

		loginTextviaEmail = loginButtonviaEmail.GetComponentInChildren<Text>();
		startGame = startGameButton.GetComponentInChildren<Text>();
		logoutButtonText = logoutButton.GetComponentInChildren<Text>();
		loginTextviaName = loginButtonviaName.GetComponentInChildren<Text>();

		//Listeners.
		registerButton.onClick.AddListener(GoToRegister);
		loginButtonviaEmail.onClick.AddListener(GoToLoginviaEmail);
		loginButtonviaName.onClick.AddListener(GoToLoginviaName);
		startGameButton.onClick.AddListener(GoToMultiplayerScene);
		logoutButton.onClick.AddListener(LogoutButtonPressed);
		yesLogout.onClick.AddListener(YesLogout);
		noDontLogout.onClick.AddListener(NoDontLogout);

		//Text Logs.
		if (DBManager.LoggedInWithEmail && !DBManager.GetUserName)
		{
			usermailDisplay.text = "User logged in as: " + DBManager.email;
			loginTextviaEmail.text = "You are LoggedIn via your Email";
			loginTextviaName.text = "You are LoggedIn via your Email";
			startGame.text = "Multiplayer.";
			logoutButtonText.text = "Logout";

			registerButton.interactable = !DBManager.LoggedInWithEmail;
			loginButtonviaEmail.interactable = !DBManager.LoggedInWithEmail;
			loginButtonviaName.interactable = !DBManager.LoggedInWithEmail;
			startGameButton.interactable = DBManager.LoggedInWithEmail;
			logoutButton.interactable = DBManager.LoggedInWithEmail;
		}
		else if (!DBManager.LoggedInWithEmail && DBManager.GetUserName)
		{
			usermailDisplay.text = "User logged in as: " + DBManager.username;
			loginTextviaEmail.text = "You are LoggedIn via your name";
			loginTextviaName.text = "You are LoggedIn via your name";
			startGame.text = "Multiplayer.";
			logoutButtonText.text = "Logout";

			registerButton.interactable = !DBManager.GetUserName;
			loginButtonviaEmail.interactable = !DBManager.GetUserName;
			loginButtonviaName.interactable = !DBManager.GetUserName;
			startGameButton.interactable = DBManager.GetUserName;
			logoutButton.interactable = DBManager.GetUserName;
		}
		else if(!DBManager.LoggedInWithEmail && !DBManager.GetUserName)
		{
			usermailDisplay.text = "User logged in as: " + DBManager.email;
			loginTextviaEmail.text = "Log in via Email";
			loginTextviaName.text = "Log in via Username";
			startGame.text = "Login to Start Multiplayer";
			logoutButtonText.text = "You are not LoggedIn";

			registerButton.interactable = true;
			loginButtonviaEmail.interactable = true;
			loginButtonviaName.interactable = true;
			startGameButton.interactable = false;
			logoutButton.interactable = false;
		}
	}

	private void GoToRegister()
	{
		Scenemanager.Loadscene("RegisterMenu");
	}

	private void GoToLoginviaEmail()
	{
		Scenemanager.Loadscene("LoginMenu");
	}

	private void GoToLoginviaName()
	{
		Scenemanager.Loadscene("LoginMenuWithName");
	}

	private void GoToMultiplayerScene()
	{
		Debug.LogError("Logged in Successfully.");

		if(DBManager.LoggedInWithEmail)
		{
			Debug.Log("Email is: " + DBManager.email);
		}
		else if (DBManager.GetUserName)
		{
			Debug.Log("UserName is: " + DBManager.username);
		}

		Debug.LogError("Give Your Scene Name Here.");

		Debug.Log("You Can Use Scene Manager Static Class,which is present in the project.");
	}

	private void LogoutButtonPressed()
	{
		if(!DBManager.LoggedInWithEmail && !DBManager.GetUserName)
		{
			logoutText.text = "No User/Email Logged in or Found.";
		}
		else if (!DBManager.LoggedInWithEmail && DBManager.GetUserName)
		{
			logoutText.text = "Logging out from " + DBManager.username;
		}
		else if (DBManager.LoggedInWithEmail && !DBManager.GetUserName)
		{
			logoutText.text = "Logging out from " + DBManager.email;
		}

		loginPanel.SetActive(false);
		logoutPanel.SetActive(true);
	}

	private void YesLogout()
	{
		if (DBManager.LoggedInWithEmail)
		{
			//DBManager.LogOutfromEmailandName();
			DBManager.LogOutfromEmail();
			Scenemanager.ReloadCurrentScene(true);
		}
		else if (DBManager.GetUserName)
		{
			//DBManager.LogOutfromEmailandName();
			DBManager.LogOutfromUserName();
			Scenemanager.ReloadCurrentScene(true);
		}
	}

	private void NoDontLogout()
	{
		loginPanel.SetActive(true);
		logoutPanel.SetActive(false);
	}
}
