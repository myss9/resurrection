using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System;
using System.Text;

public class CameraS : MonoBehaviour 
{

	private GameObject connector;

	void Start(){
		connector = GameObject.Find("TCPConnector");
	}

	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit hit;
						//UdpClient udpClient = new UdpClient();
						//udpClient.Connect("127.0.0.1", 21);

						//Byte[] sendBytes = Encoding.ASCII.GetBytes("hit.point");
			             //Byte[] sendBytes = Encoding.ASCII.GetBytes(hit.point.ToString());
						//udpClient.Send(sendBytes, sendBytes.Length);

						
			//RaycastHit hit;
			//print("click");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) 
			{
				print(hit.point.ToString());
				connector.GetComponent<TCPConnector>().WriteString(hit.point.ToString());
				//udpClient.Send(sendBytes, sendBytes.Length);

			}
		}
	}
}
