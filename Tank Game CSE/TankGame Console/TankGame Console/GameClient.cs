using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TankGame_Console
{
    class GameClient
    {
        public void runClient() {
            try
            {
                IPAddress ip = new IPAddress("127.0.0.1");
                TcpListener listener = new TcpListener(, 7000);

                listener.Start();

                
                {
                    Console.Write("Waiting for connection...");
                    TcpClient client = listener.AcceptTcpClient();

                    Console.WriteLine("Connection accepted.");
                    NetworkStream ns = client.GetStream();

                    byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString());

                    try
                    {
                        ns.Write(byteTime, 0, byteTime.Length);
                        ns.Close();
                        client.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                

                listener.Stop();




                TcpClient client = new TcpClient("127.0.0.1", 6000);

                NetworkStream ns = client.GetStream();

                byte[] bytes = new byte[1024];
                int bytesRead = ns.Read(bytes, 0, bytes.Length);

                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRead));

                client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }


    }
}
