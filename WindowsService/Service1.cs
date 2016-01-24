using System;
using System.ServiceProcess;
using DemoLibrary;

namespace WindowsService
{
   public partial class Service1 : ServiceBase
   {
      IDisposable _demo;

      public Service1()
      {
         InitializeComponent();
      }

      protected override void OnStart(string[] args)
      {
         var url = "http://+:8080";
         _demo = Startup.Start(url);
      }

      protected override void OnStop()
      {
         if (_demo != null)
            _demo.Dispose();
      }
   }
}
