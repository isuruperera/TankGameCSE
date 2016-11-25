using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tanks
{
    class TankListener 
    {
        TcpListener listener;
        bool isConnected = false;
        public void startListening() {
            ThreadStart threadStart = new ThreadStart(update);
            Thread t = new Thread(threadStart);
            t.Start();
            
        }

        public void update() {
            Console.WriteLine("Update from server: /n /n");          
            try
            {
                int port = 7000;
                IPAddress host = IPAddress.Parse("127.0.0.1");
                listener = new TcpListener(host, port);

                listener.Start();
                Byte[] byteStream = new Byte[256];
                String data;

                while (!isConnected)
                {
                    
                    TcpClient client = listener.AcceptTcpClient();
                    if (client != null)
                    {
                        isConnected = true;                       
                    }

                    NetworkStream netStream = client.GetStream();
                    int i;
                    while ((i = netStream.Read(byteStream, 0, byteStream.Length)) != 0)
                    {
                        data = Encoding.ASCII.GetString(byteStream, 0, i);
                        Console.WriteLine("Received:" + data);
                        data = data.ToUpper();
                    }
                    isConnected = false;
                    
                }

            }
            catch (Exception e)
            {
                //log for errors
               // Console.WriteLine(e.StackTrace);
            }
            finally {
                //clients are not closed yet due to an error, change them into global variables and 
            }
        }
    }
}
