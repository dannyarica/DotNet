using System;
using System.Runtime.Remoting;

namespace ComponentHost
{
    public class Host
    {
        private static void Main(string[] args)
        {
            RemotingConfiguration.Configure("ComponentHost.exe.config", false);

            Console.WriteLine("Hi am your server, please be free to send any call. I 'd love to accomplish it.!! :D");

            Console.WriteLine("Now I am Listening .. ");
            Console.Read();
        }
    }
}