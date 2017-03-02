using System.Runtime.Remoting;
using MyRemoteObject;
using System;

namespace RemotingClient
{
    public class Client
    {
        private const string HOSTNAME = "172.27.113.143";
        private const string PORT = "8737";

        private static void Main(string[] args)
        {
            CallingByHardCoding();

            CallByReadingConfigFile();
            Console.ReadKey();
        }

        private static void CallingByHardCoding()
        {
            var grettingsUrl = string.Format(@"tcp://{0}:{1}/Greetings.rem", HOSTNAME, PORT);
            var localGreetings = (Greetings)Activator.GetObject(typeof(Greetings), grettingsUrl);
            localGreetings.Greet("Calling a ...anyone");

            //Uncomment if you need to test this feature
            //var createFolderUrl = string.Format(@"tcp://{0}:{1}/CreateFolder.rem", HOSTNAME, PORT);
            //var localCreateFolder = (CreateFolder)Activator.GetObject(typeof(CreateFolder), createFolderUrl);
            //localCreateFolder.Run(201, 5);
        }

        private static void CallByReadingConfigFile()
        {
            RemotingConfiguration.Configure("RemotingClient.exe.config", false);

            var grettingsUrl = GetApplicationURL(typeof(Greetings));

            var localGreetings = (Greetings)Activator.GetObject(typeof(Greetings), grettingsUrl);
            localGreetings.Greet("Danny :$");
        }

        private static string GetApplicationURL(Type Type)
        {
            ActivatedClientTypeEntry entry = null;

            foreach (ActivatedClientTypeEntry temp in RemotingConfiguration.GetRegisteredActivatedClientTypes())
            {
                if (temp.TypeName.Equals(Type.FullName))
                {
                    entry = temp;
                    break;
                }
            }

            if (entry == null)
                throw new ArgumentException(String.Format("Type {0} not found.", Type.FullName));

            return entry.ApplicationUrl;
        }
    }
}