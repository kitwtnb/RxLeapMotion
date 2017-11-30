using RxLeapMotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            IRxLeap leap = new RxLeap();
            leap.Connect.Subscribe(c => Console.WriteLine("Connect"));
            leap.Disconnect.Subscribe(c => Console.WriteLine("Disconnect"));
            leap.Init.Subscribe(c => Console.WriteLine("Init"));
            leap.Exit.Subscribe(c => Console.WriteLine("Exit"));
            leap.FocusGained.Subscribe(c => Console.WriteLine("FocusGained"));
            leap.FocusLost.Subscribe(c => Console.WriteLine("FocusLost"));
            leap.Frame.Subscribe(c => Console.WriteLine("Frame"));

            Console.Read();
        }
    }
}
