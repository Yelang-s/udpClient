using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace udpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient();
          
            IPEndPoint iPEndPoint = new System.Net.IPEndPoint(IPAddress.Parse("192.168.43.201"), 6000);
            client.Connect(iPEndPoint);
            while (true)
            {
                string msg = Console.ReadLine();
                byte[] w = Encoding.UTF8.GetBytes(msg);
                client.Send(w, w.Length);
                byte[] datas = client.Receive(ref iPEndPoint);
                string data = Encoding.UTF8.GetString(datas, 0, datas.Length);
                Console.WriteLine($"收到来自-->{iPEndPoint}的信息:{data}");

            }

        }
    }
}
