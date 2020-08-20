using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login : MonoBehaviour
{
	private InputField emailField, passwordField;
	private Button loginButton, registerButton,mainmenuButton;
	private string path;

	void Start()
	{
		emailField = transform.GetChild(1).transform.GetChild(1).GetComponent<InputField>();
		passwordField = transform.GetChild(2).transform.GetChild(1).GetComponent<InputField>();
		loginButton = transform.GetChild(3).GetComponent<Button>();
		registerButton = transform.GetChild(4).transform.GetChild(1).GetComponent<Button>();
		mainmenuButton = transform.GetChild(5).transform.GetChild(1).GetComponent<Button>();

		path = "http://localhost/forname/login.php";

		loginButton.onClick.AddListener(CallLogin);
		registerButton.onClick.AddListener(GoToRegisterMenu);
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
		form.AddField("email", emailField.text);
		form.AddField("password", passwordField.text);

		WWW www = new WWW(path, form);
		yield return www;

		if (www.text[0] == '0')
		{
			DBManager.email = emailField.text;
			Scenemanager.Loadscene("MainMenu");
		}
		else
		{
			Debug.Log("User login failed. Error #" + www.text);
		}
	}

	public void VerifyInputs()
	{
		loginButton.interactable = (emailField.text.Contains("@") && emailField.text.Contains(".") && emailField.text.Length >= 12 && passwordField.text.Length >= 8);
	}	
}
