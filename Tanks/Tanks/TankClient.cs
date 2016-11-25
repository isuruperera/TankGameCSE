using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    class TankClient
    {
        private const int portNum = 6000;
        private const string hostName = "127.0.0.1";
        
        // Method for issuing a command to the server
        public void executeCommand(String command)
        {
            try
            {
                using (var client = new TcpClient(hostName, portNum))
                {
                    var byteData = Encoding.ASCII.GetBytes(command);
                    client.GetStream().Write(byteData, 0, byteData.Length);
                }
            }
            catch (Exception ex)
            {
                //log for errors in the future
                //for now logging uses console output
                Console.WriteLine("Exception!");
            }

        }

    }
}
