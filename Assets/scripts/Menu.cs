using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void OnGUI ()
	{
		if (GUI.Button (new Rect (150, 10, 100, 40), "Начать тест")) 
		{
			Application.LoadLevel ("Sc1");
		}
		if (GUI.Button (new Rect (150, 50, 100, 40), "Chat")) 
		{
			Application.LoadLevel ("test_chat");
		}
		if (GUI.Button (new Rect (150, 400, 100, 40), "Да Ну Нахер")) 
		{
			Application.Quit();
		}
	}
}
