using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login : MonoBehaviour
{
	[SerializeField] private InputField emailField, passwordField;
	[SerializeField] private Button loginButton, registerButton;
	[SerializeField] private string path;

	void Start()
	{
		registerButton.onClick.AddListener(GoToRegisterMenu);
		loginButton.onClick.AddListener(CallLogin);
	}

	private void GoToRegisterMenu()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("RegisterMenu");
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
			Launcher.launcherIsLoggedIn = true;
			DBManager.email = emailField.text;
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
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
