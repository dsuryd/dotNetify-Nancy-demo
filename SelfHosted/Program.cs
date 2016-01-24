using System;
using DemoLibrary;

namespace SelfHosted
{
   class Program
   {
      static void Main(string[] args)
      {
         var url = "http://+:8080";

         using (Startup.Start(url))
         {
            Console.WriteLine("Running on {0}", url);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
         }
      }
   }
}
