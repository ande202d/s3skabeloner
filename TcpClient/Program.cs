using System;

namespace TcpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            c.Start();
            Console.ReadKey();
        }
    }
}
