using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tanks
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGameRunning = true;
            TankListener tl = new TankListener();
            tl.startListening();           
            TankClient tc = new TankClient();
            //Join the game
            tc.executeCommand("JOIN#");
            Console.WriteLine("Connected to server!");
            while (isGameRunning) {

                //Fix the order of updating the server and he listening to the data stream. Other order won't work
                //listen to the server and update the game internal variables
                //tl.update();

                //Capture keyboard input and control tanks accordingly
                ConsoleKeyInfo key = Console.ReadKey();
                
                if (key.Key == ConsoleKey.RightArrow) {
                    tc.executeCommand("RIGHT#");
                    Console.WriteLine("Got Right Arrow!");
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    tc.executeCommand("DOWN#");
                    Console.WriteLine("Got Down Arrow!");
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    tc.executeCommand("LEFT#");
                    Console.WriteLine("Got Left Arrow!");
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    tc.executeCommand("UP#");
                    Console.WriteLine("Got Up Arrow!");
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    tc.executeCommand("SHOOT#");
                    Console.WriteLine("Got Spacebar SHOOT!!!!!");
                }
                
                Thread.Sleep(500);
            }
        }
    }
}
