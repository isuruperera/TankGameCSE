using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TankGame_Console
{
    class Program
    {
        private const int portNum = 13;
        private const string hostName = "host.contoso.com";

        static void Main(string[] args)
        {
            GameClient tcp = new GameClient();
            
            tcp.runClient();
            while (true) { }


        }

        public void tcp() {

        
}
    }
}
