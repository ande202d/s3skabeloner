using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    public class Server
    {
        public void Start()
        {
            //IP configuration
            IPAddress ipa = IPAddress.Parse("127.0.0.1");

            TcpListener tcp = new TcpListener(ipa, 7000);

            //Starting Server and sending the accepted client to a "DoClient"
            tcp.Start();
            Console.WriteLine("Server Started");

            while (true)
            {
                Task.Run(() =>
                {
                    TcpClient tempSocket = tcp.AcceptTcpClient();
                    EndPoint clientIP = tempSocket.Client.RemoteEndPoint;
                    Console.WriteLine(clientIP + ": CONNECTED");

                    DoClient(tempSocket);

                    if (!tempSocket.Connected) Console.WriteLine(clientIP + ": DISCONNECTED");
                    tempSocket.Close();
                });
            }

            tcp.Stop();
        }
        public void DoClient(System.Net.Sockets.TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string message;

            while (true)
            {
                try
                {
                    message = sr.ReadLine();
                    Console.WriteLine("input: " + message);
                    string answer = "";

                    //if (string.IsNullOrWhiteSpace(message)) break;

                    //////////////////////////////////////////////////////////////////////
                    /// HERE YOU WRITE YOUR PROTOCOL (WHAT TO DO WITH THE MESSAGE)
                    //////////////////////////////////////////////////////////////////////

                    answer = message.ToUpper();

                    Console.WriteLine("output: " + answer);
                    sw.WriteLine(answer);
                }
                catch (IOException e)
                {
                    break;
                }
            }

            ns.Close();
        }
    }
}
