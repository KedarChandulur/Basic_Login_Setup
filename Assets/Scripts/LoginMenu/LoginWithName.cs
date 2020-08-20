using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginWithName : MonoBehaviour
{
	private InputField nameField, passwordField;
	private Button loginButton, registerButton, mainmenuButton;
	private string path;

	void Start()
	{
		nameField = transform.GetChild(1).transform.GetChild(1).GetComponent<InputField>();
		passwordField = transform.GetChild(2).transform.GetChild(1).GetComponent<InputField>();
		loginButton = transform.GetChild(3).GetComponent<Button>();
		registerButton = transform.GetChild(4).transform.GetChild(1).GetComponent<Button>();
		mainmenuButton = transform.GetChild(5).transform.GetChild(1).GetComponent<Button>();

		path = "http://localhost/forname/loginwith_username.php";

		registerButton.onClick.AddListener(GoToRegisterMenu);
		loginButton.onClick.AddListener(CallLogin);
		mainmenuButton.onClick.AddListener(GoToMainMenu);
	}

	private void GoToMainMenu()
	{
		Scenemanager.Loadscene("MainMenu");
	}

	private void GoToRegisterMenu()
	{
		Scenemanager.Loadscene("RegisterMenu");
	}

	private void CallLogin()
	{
		StartCoroutine(LoginUser());
	}

	IEnumerator LoginUser()
	{
		WWWForm form = new WWWForm();
		form.AddField("name", nameField.text);
		form.AddField("password", passwordField.text);

		WWW www = new WWW(path, form);
		yield return www;

		if (www.text[0] == '0')
		{
			DBManager.username = nameField.text;
			Scenemanager.Loadscene("MainMenu");
		}
		else
		{
			Debug.Log("User login failed. Error #" + www.text);
		}
	}

	public void VerifyInputs()
	{
		loginButton.interactable = (nameField.text.Length >= 3 && passwordField.text.Length >= 8);
	}	
}
