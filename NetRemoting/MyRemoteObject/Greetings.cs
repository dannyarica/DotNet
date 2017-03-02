using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace MyRemoteObject
{
    public class Greetings : MarshalByRefObject
    {
        public Greetings()
        {
            Console.WriteLine("Calling Greetings Service...");
        }

        public void Greet(string message)
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName + " says:" + message);
        }
    }
}