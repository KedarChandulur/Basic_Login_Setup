using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Login : MonoBehaviour
{
	private InputField emailField, passwordField;
	private Button loginButton, registerButton;
	private string path;

	void Start()
	{
		emailField = transform.GetChild(1).transform.GetChild(1).GetComponent<InputField>();
		passwordField = transform.GetChild(2).transform.GetChild(1).GetComponent<InputField>();
		loginButton = transform.GetChild(3).GetComponent<Button>();
		registerButton = transform.GetChild(4).transform.GetChild(1).GetComponent<Button>();

		path = "http://localhost/forname/login.php";

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
