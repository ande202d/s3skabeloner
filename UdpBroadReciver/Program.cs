using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UdpBroadReciver
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpReceiver = new UdpClient(7000);
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7000);
            Console.WriteLine("Receiver is blocked");

            //int i = 0; //noget som passer til eksemplet



            try
            {
                while (true)
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref RemoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("Recived: " + receivedData.ToString());

                    /////////////////////////////////////////////////////////////
                    /// HER KAN DU SE HVAD DIN RECIVER MODTAGER FRA UDSENDEREN
                    /////////////////////////////////////////////////////////////

                    #region eksempel på at sende den modtaget data til en rest service

                    //using (var client = new HttpClient())
                    //{
                    //    client.BaseAddress = new Uri("https://shoppersizerrest.azurewebsites.net/api/");
                    //    //client.BaseAddress = new Uri("https://localhost:44375/api/");
                    //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //    string stringToSend = "{\"number\":" + int.Parse(receivedData) + "}";

                    //    var response = client.PutAsync("LiveNumber/1", new StringContent(stringToSend, Encoding.UTF8, "application/json")).Result;
                    //    if (response.IsSuccessStatusCode)
                    //    {
                    //        Console.Write("Success");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("Error");
                    //    }

                    //    if (i >= 2)
                    //    {
                    //        var result = client.GetAsync("LiveNumber/1");
                    //        var toSend = result.Result.Content.ReadAsStringAsync().Result;
                    //        var st = toSend.Split(':').Last().Split('}').First();
                    //        //Console.WriteLine(st);
                    //        var response2 = client.PostAsync("datasets", new StringContent("{\"count\":" + st + "}", Encoding.UTF8, "application/json")).Result;
                    //        //new StringContent(result.ToString())
                    //        if (response2.IsSuccessStatusCode)
                    //        {
                    //            Console.Write("Success");
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("Error");
                    //        }
                    //        i = 0;
                    //    }
                    //    i++;

                    //}

                    #endregion

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
