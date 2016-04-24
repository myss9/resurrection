using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System;
using System.Text;

public class ts_but : MonoBehaviour {

	private GameObject connector;

	void Start(){
		connector = GameObject.Find("TCPConnector");
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (150, 10, 100, 40), "Создать")) 
		{
			string json = "{\"action\":\"create\",\"data\":{\"string\":\"test\",\"int\":1}}";
			connector.GetComponent<TCPConnector>().WriteString(json);
		}
		if (GUI.Button (new Rect (150, 50, 100, 40), "Закрыть")) 
		{
			string json = "{\"action\":\"close\",\"data\":{\"string\":\"test1\",\"int\":2}}";
			connector.GetComponent<TCPConnector>().WriteString(json);
		}
		if (GUI.Button (new Rect (150, 400, 100, 40), "Да Ну Нахер")) 
		{
			Application.Quit();
		}
	}
}
