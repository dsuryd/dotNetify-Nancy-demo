using Nancy;

namespace DemoLibrary
{
   public class HomeModule : NancyModule
   {
      public HomeModule()
      {
         Get["/"] = x => View["Dashboard.html"];
      }
   }
}
