using Nancy;

namespace DemoLibrary
{
   public class HomeModule : NancyModule
   {
      public HomeModule()
      {
         // Process Monitor demo.
         Get["/"] = x => View["Dashboard.html"];

         // Other examples as seen in the dotNetify website.
         Get["/examples"] = x => View["ExamplesIndex.html"];
         Get["/examples/{id}"] = x => View[x.id + ".html"];
      }
   }
}
