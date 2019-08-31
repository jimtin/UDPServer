using System;
using System.Net;

namespace UdpReceiver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            UDPSocket s = new UDPSocket();
            if (args.Length == 0)
            {
                System.Console.WriteLine("No arguments entered");
                System.Console.WriteLine("Default IP 127.0.0.1 used");
                System.Console.WriteLine("Default Port 9991 used");
                s.Server("127.0.0.1", 9991);
                // Send a test Datagram
                UDPSocket c = new UDPSocket();
                c.Client("127.0.0.1", 9991);
                c.Send("TEST!");
            }
            else if(args.Length != 2)
            {
                System.Console.WriteLine("Incorrect number of arguments entered");
            }
            else
            {
                try
                {
                    var port = Int32.Parse(args[1]); //int.Parse(args[1]);
                    Console.WriteLine("Custom settings used");
                    Console.WriteLine($"IP: {args[0]}");
                    Console.WriteLine($"Port: {port}");
                    //s.Server(ip, port);
                    s.Server(args[0], port);
                    
                    // Send a test Datagram
                    UDPSocket c = new UDPSocket();
                    c.Client(args[0], port);
                    c.Send("HostHunter is Awesome!");
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e);
                }
            }
            
            

            Console.ReadKey();
        }
    }
}