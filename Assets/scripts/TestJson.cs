using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System;
using System.Text;

public class TestJson : MonoBehaviour {

	const int PORT = 10000;
	Client client;

	void Start(){
		client = new Client(PORT, "127.0.0.1");
		client.Work();
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (150, 10, 100, 40), "Создать")) 
		{
			string json = "{\"action\":\"create\",\"data\":{\"string\":\"test\",\"int\":1}}";
			Debug.Log("create clicked");
			client.SendJson(json);
		}
		if (GUI.Button (new Rect (150, 50, 100, 40), "Закрыть")) 
		{
			string json = "{\"action\":\"close\",\"data\":{\"string\":\"test1\",\"int\":2}}";
			Debug.Log("close clicked");
			client.SendJson(json);
		}
		if (GUI.Button (new Rect (150, 400, 100, 40), "Да Ну Нахер")) 
		{
			Application.Quit();
		}
	}
}
