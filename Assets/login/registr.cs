using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class registr : MonoBehaviour {
	public GameObject username;
	public GameObject email;
	public GameObject password;
	public GameObject confpassword;
	private string UserName;
	private string EMail;
	private string Password;
	private string ConfPassword;
	private string form;
	private bool EmailValid = false;
	private string[] Characters = {"q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m",
								   "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M",
		                           "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "_"};

	public void RegistrationButton(){
		bool UN = false;
		bool EM = false;
		bool PW = false;
		bool CPW = false;

		if (UserName != "") {//проверяем существует ли такой пользователь
			if (!System.IO.File.Exists (@"место где хранится инфа по юзерам" + UserName + ".txt")) {
				UN = true;
			} else {
				Debug.LogWarning ("Username Taken");
			}
		} else {
			Debug.LogWarning ("Username field Empty");
		}
		if (EMail != "") {//проверяем правильность заполенения поля с мылом
			EmailValidation();
			if (EmailValid) {
				if (EMail.Contains ("@")) {
					if (EMail.Contains (".")) {
						EM = true;
					}else {
						Debug.LogWarning("Email is Incorect");
					}
				}else {
					Debug.LogWarning("Email is Incorect");
				}
			}else {
				Debug.LogWarning("Email is Incorect");
			}
		} else {
			Debug.LogWarning ("Email Field Empty");
		}
		if (Password != "") {//непосредственно рабоатем с паролем
			if (Password.Length > 5) {
				PW = true;
			} else {
				Debug.LogWarning ("Password korotki");
			}
		} else {
			Debug.LogWarning ("Password fiel empty");
		}
		if (ConfPassword != "") {
			if (ConfPassword == Password) {
				CPW = true;
			} else {
				Debug.LogWarning ("Passwords nesovpadae slich");
			}
		} else {
			Debug.LogWarning ("Confirme Password field empty");
		}
		if (UN == true && EM == true && PW == true && CPW == true) {/*так как урок бы на анлийском, я понимал через слово, 
		и если правильно понял, то в данной части собираются все данные, шифруются и отправляются в баззу данных пользователей*/
			bool Clear = true;
			int i = 1;
			foreach (char c in Password) {
				if (Clear) {
					Password = "";
					Clear = false;
				}
				i++;
				char Encrypted = (char)(c * i);
				Password += Encrypted.ToString ();
			}
			form = (UserName+Environment.NewLine+EMail+Environment.NewLine+Password);
			System.IO.File.WriteAllText(@"адрес где все хранится"+UserName+".txt", form);
			username.GetComponent<InputField> ().text = "";
			email.GetComponent<InputField> ().text = "";
			password.GetComponent<InputField> ().text = "";
			confpassword.GetComponent<InputField> ().text = "";
			print ("Registration Complite");
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField>().isFocused){
				email.GetComponent<InputField> ().Select ();
			}
			if (email.GetComponent<InputField>().isFocused){
				password.GetComponent<InputField> ().Select ();
			}
			if (password.GetComponent<InputField>().isFocused){
				confpassword.GetComponent<InputField> ().Select ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (UserName != "" && EMail != "" && Password != "" && ConfPassword != "") {
				RegistrationButton ();
			}
		}
		UserName = username.GetComponent<InputField> ().text;
		EMail = email.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;
		ConfPassword = confpassword.GetComponent<InputField> ().text;
	}
	void EmailValidation(){
		bool SW = false;
		bool EW = false;
		for (int i = 0; i < Characters.Length; i++) {
			if (EMail.StartsWith (Characters [i])) {
				SW = true;
			}
		}
		for (int i = 0; i < Characters.Length; i++) {
			if (EMail.EndsWith (Characters [i])) {
				EW = true;
			}
		}
		if (SW == true && EW == true) {
			EmailValid = true;
		} else {
			EmailValid = false;
		}
	}
}
