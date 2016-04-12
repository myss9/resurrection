using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System;
using System.Text;

public class CameraS : MonoBehaviour 
{

	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			RaycastHit hit;
						UdpClient udpClient = new UdpClient();
						udpClient.Connect("127.0.0.1", 21);

						//Byte[] sendBytes = Encoding.ASCII.GetBytes("hit.point");
			             Byte[] sendBytes = Encoding.ASCII.GetBytes(hit.point.ToString());
						//udpClient.Send(sendBytes, sendBytes.Length);

						
			//RaycastHit hit;

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) 
			{
				print(hit.point);
				udpClient.Send(sendBytes, sendBytes.Length);

				}
		}
	}
}
