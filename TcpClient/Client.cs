using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TcpClient
{
    public class Client
    {
        public void Start()
        {
            Console.WriteLine("Waiting for server");
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient("127.0.0.1", 7000);


            NetworkStream ns = client.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            Console.WriteLine("Connected to server " + client.Client.RemoteEndPoint);


            string message = "";

            while (message != null || message != "")
            {
                message = Console.ReadLine();

                sw.WriteLine(message);

                Console.WriteLine(sr.ReadLine());
            }

            ns.Close();
            client.Close();

        }
    }
}
