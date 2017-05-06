using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Client
    {
        public static TcpClient client; //??
        const int port = 90;

        public Client()
        {
            client = new TcpClient();
            client.Connect(IPAddress.Parse("192.168.1.7"), port);
            Thread clientListener = new Thread(RecvMessage);
            clientListener.IsBackground = true;
            clientListener.Start();
        }

        public void SendMessage(string message)
        {
            message.Trim();
            byte[] buffer = Encoding.ASCII.GetBytes((message).ToCharArray());
            client.GetStream().Write(buffer, 0, buffer.Length);
        }

        public static void RecvMessage()
        {
            while (true)
            {
                NetworkStream NS = client.GetStream();
                List<byte> buffer = new List<byte>();
                while (NS.DataAvailable)
                {
                    int ReadByte = NS.ReadByte();
                    if (ReadByte > -1)
                    {
                        buffer.Add((byte)ReadByte);
                    }
                }
                if (buffer.Count > 0)
                {
                    string msg = Encoding.ASCII.GetString(buffer.ToArray());
                    Chatty.Get_NewMsg(msg);
                }
            }
        }
    }
}
