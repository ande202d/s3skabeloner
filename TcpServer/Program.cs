using System;

namespace TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server();
            s.Start();
            Console.ReadKey();
        }
    }
}
