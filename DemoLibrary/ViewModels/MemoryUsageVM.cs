using System;
using System.Diagnostics;
using DotNetify;

namespace DemoLibrary
{
   public class MemoryUsageVM : BaseVM
   {
      private PerformanceCounter _memoryCounter = new PerformanceCounter("Process", "Working Set - Private", "_Total");

      public string Title
      {
         get { return Get<string>(); }
         set { Set(value); }
      }

      public double Data
      {
         get
         {
            try
            {
               return Math.Round(_memoryCounter.NextValue() / 1024, 2);
            }
            catch(Exception ex)
            {
               Trace.WriteLine(ex.Message);
               return 0;
            }
         }
      }

      public int ProcessId
      {
         set
         {
            var processName = ProcessVM.GetProcessInstanceName(value);
            if (processName != null)
            {
               _memoryCounter.Dispose();
               _memoryCounter = new PerformanceCounter("Process", "Working Set - Private", processName);
               Title = "Memory Usage - " + processName;
            }
         }
      }

      public MemoryUsageVM()
      {
         Title = "Memory Usage";
      }

      public override void Dispose()
      {
         _memoryCounter.Dispose();
         base.Dispose();
      }

      public void Update()
      {
         Changed(() => Data);
         PushUpdates();
      }
   }
}
