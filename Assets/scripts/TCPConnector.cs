using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;

public class TCPConnector : Singleton<TCPConnector> {

	public bool socketReady = false;
	private TcpClient mySocket;
	private NetworkStream theStream;
	private StreamWriter theWriter;
	private StreamReader theReader;

	void Start(){
		string host = "127.0.0.1";
		int port = 8007;
		setupSocket (host, port);
	}


	void Update()
	{
		string t = this.ReadString();
		if ((t != "") && (socketReady))
		{
			Debug.Log ("Message from server: " + t);
		}
	}
	
	
	void OnApplicationQuit()
	{
		closeSocket();
	}
	
	public bool setupSocket(string Host, int Port)
	{
		try
		{
			mySocket = new TcpClient(Host, Port);
			mySocket.Connect(Host, Port);
			theStream = mySocket.GetStream();
			theWriter = new StreamWriter(theStream);
			theReader = new StreamReader(theStream);
			socketReady = true;
			Debug.Log("Connected to server " + Host + ":" + Port);
			return true;
		}
		catch (Exception e)
		{
			Debug.Log("Socket error: " + e);
			return false;
		}
	}
	
	public void WriteString(string theLine)
	{
		if (!socketReady) return;
		String foo = theLine + "\r\n";
		theWriter.Write(foo);
		theWriter.Flush();
	}
	
	public string ReadString()
	{
		if ((socketReady) && (mySocket.Connected))
		{
			//Debug.Log ("In Read String 1");
			if (theStream.DataAvailable)
				return theReader.ReadLine();
			//Debug.Log ("In Read String 2");
		}
		return "";
	}
	
	public void closeSocket()
	{
		if ((socketReady) && (mySocket.Connected))
		{
			theWriter.Close();
			theReader.Close();
			mySocket.Close();
			socketReady = false;
			Debug.Log ("Disconnected");
		}
	}
	
}