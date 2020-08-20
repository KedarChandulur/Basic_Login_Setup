using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Registration : MonoBehaviour
{
	private InputField nameField, emailField, passwordField;
	private Button registerButton, loginButton, mainmenuButton;
	private string path;

	private void Start()
	{
		nameField = transform.GetChild(1).transform.GetChild(1).GetComponent<InputField>();
		emailField = transform.GetChild(2).transform.GetChild(1).GetComponent<InputField>();
		passwordField = transform.GetChild(3).transform.GetChild(1).GetComponent<InputField>();
		registerButton = transform.GetChild(4).GetComponent<Button>();
		loginButton = transform.GetChild(5).transform.GetChild(1).GetComponent<Button>();
		mainmenuButton = transform.GetChild(6).transform.GetChild(1).GetComponent<Button>();

		path = "http://localhost/forname/register.php";

		loginButton.onClick.AddListener(GoToLoginMenu);
		registerButton.onClick.AddListener(CallRegister);
		mainmenuButton.onClick.AddListener(GoToMainMenu);
	}

	private void GoToMainMenu()
	{
		Scenemanager.Loadscene("MainMenu");
	}

	private void GoToLoginMenu()
	{
		Scenemanager.Loadscene("LoginMenu");
	}

	private void CallRegister()
	{
		StartCoroutine(Register());
	}

	IEnumerator Register()
	{
		WWWForm form = new WWWForm();
		//nameField.text += "#" + Random.Range(1000, 10000);
		form.AddField("name", nameField.text);
		form.AddField("email", emailField.text);
		form.AddField("password", passwordField.text);

		WWW www = new WWW(path, form);
		yield return www;

		if(www.text == "0")
		{
			Debug.Log("User created sucessfully.");
			Scenemanager.Loadscene("MainMenu");
		}
		else
		{
			Debug.Log("User creation failed. Error." + www.text);
		}
	}

	public void VerifyInputs()
	{
		registerButton.interactable = (nameField.text.Length >= 3 && emailField.text.Contains("@") && emailField.text.Contains(".") && emailField.text.Length >= 12 && passwordField.text.Length >= 8);
	}
}
