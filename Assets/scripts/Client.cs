using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using UnityEngine;

    class Client
    {
        static TcpClient client;

        public Client(int Port, string connectIp)
        {
            client = new TcpClient();
            client.Connect(IPAddress.Parse(connectIp), Port);
        }

        public void Work()
        {
            Thread clientListener = new Thread(Reader);
            clientListener.Start();
        }

        public void SendMessage(string message)
        {
            message.Trim();
			byte[] Buffer = Encoding.UTF8.GetBytes((message).ToCharArray());
            client.GetStream().Write(Buffer, 0, Buffer.Length);
            Chat.message.Add(message);
        }

		public void SendJson(string json)
		{
			json.Trim();
			byte[] Buffer = Encoding.UTF8.GetBytes(json);
			client.GetStream().Write(Buffer, 0, Buffer.Length);
		}

        static void Reader()
        {
            while (true)
            {
                NetworkStream NS = client.GetStream();
                List<byte> Buffer = new List<byte>();
                while (NS.DataAvailable)
                {
                    int ReadByte = NS.ReadByte();
                    if (ReadByte > -1)
                    {
                        Buffer.Add((byte)ReadByte);
                    }
                }
				if (Buffer.Count > 0) 
				{
					String incomingMessage = Encoding.UTF8.GetString (Buffer.ToArray ());
					Debug.Log("Incoming message: " + incomingMessage);
					Chat.message.Add (incomingMessage);
				}
            }
        }

        ~Client()
        {
            if (client != null)
            {
                client.Close();
            }
        }
    }