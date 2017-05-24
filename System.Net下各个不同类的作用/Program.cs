using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace System.Net下各个不同类的作用
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress address = IPAddress.Parse("192.168.137.5");
            IPEndPoint ip1 = new IPEndPoint(address, 108);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ip1);
            socket.Listen(0);

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Socket client = socket.Accept();
                    Task.Factory.StartNew(() =>
                    {
                        byte[] data = new byte[1024];
                        while (true)
                        {
                            int length = client.Receive(data, data.Length, SocketFlags.None);
                            string body = System.Text.Encoding.ASCII.GetString(data, 0, length);
                            Console.WriteLine(body);
                        }
                    }
                    );
                }         
            });

            Console.ReadKey();
        }
    }
}
