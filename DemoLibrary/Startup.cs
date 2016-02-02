using System;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Owin;
using DotNetify;

[assembly: OwinStartup(typeof(DemoLibrary.Startup))]
namespace DemoLibrary
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.MapSignalR();
         app.UseNancy();

         VMController.RegisterAssembly(typeof(HomeModule).Assembly);
         VMController.RegisterAssembly(typeof(ExamplesLibrary.TreeViewVM).Assembly);
      }

      public static IDisposable Start(string url)
      {
         return WebApp.Start<Startup>(url);
      }
   }
}
