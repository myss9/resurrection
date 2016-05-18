using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class login : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	private string UserName;
	private string Password;
	private String[] Lines;
	private String DecryptedPass;

	public void LoginButton ()
	{
		bool UN = false;
		bool PW = false;

		if (UserName != "") {
			if (System.IO.File.Exists (@"место где хранится инфа по юзерам" + UserName + ".txt")) {
				UN = true;
				Lines = System.IO.File.ReadAllLines (@"место где хранится инфа по юзерам" + UserName + ".txt");
			} else {
				Debug.LogWarning ("username invalid");
			}
		} else {
			Debug.LogWarning ("Username field empty");
		}
		if (Password != "") {
			if (System.IO.File.Exists (@"место где хранится инфа по юзерам" + UserName + ".txt")) {
				int i = 1;
				foreach (char c in Lines[2]) {
					i++;
					char Decrypted = (char)(c / i);
					DecryptedPass += Decrypted.ToString ();
				}
				if (Password == DecryptedPass) {
					PW = true;
				} else {
					Debug.LogWarning ("Password invalid");
				}
			} else {
				Debug.LogWarning ("Password invalid");
			}
		} else {
			Debug.LogWarning ("Passwor field empty");
		}
		if (UN == true && PW == true) {
			username.GetComponent<InputField> ().text = "";
			password.GetComponent<InputField> ().text = "";
			print ("Login Sucessful");
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (UserName != "" && Password != "") {
				LoginButton ();
			}
		}
		UserName = username.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;
	}
}
