using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UdpBroadServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //SENDER ET RANDOM TAL HVERT 1000ms
            //PÅ PORT 7000

            Random rand = new Random();

            UdpClient udpServer = new UdpClient(0);
            udpServer.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 7000);

            Console.WriteLine("Broadcast started: Press Enter");
            Console.ReadLine();

            while (true)
            {
                int rn = rand.Next(0, 101);
                //0-40 = -1
                //41-60 = 0
                //61-90 = 1
                //91-100 = 2
                int number = 0;
                if (rn >= 0 && rn <= 40) number = -1;
                else if (rn >= 41 && rn <= 60) number = 0;
                else if (rn >= 61 && rn <= 90) number = 1;
                else if (rn >= 91 && rn <= 100) number = 2;

                Byte[] sendBytes = Encoding.ASCII.GetBytes(number.ToString());
                try
                {
                    udpServer.Send(sendBytes, sendBytes.Length, endPoint);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                Console.WriteLine(" " + number);
                Thread.Sleep(1000);
            }
        }
    }
}
