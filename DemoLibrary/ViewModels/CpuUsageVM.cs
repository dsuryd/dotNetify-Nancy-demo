using System;
using System.Diagnostics;
using DotNetify;

namespace DemoLibrary
{
   public class CpuUsageVM : BaseVM
   {
      private PerformanceCounter _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

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
               return Math.Round((double)_cpuCounter.NextValue(), 2);
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
               _cpuCounter.Dispose();
               _cpuCounter = new PerformanceCounter("Process", "% Processor Time", processName);
               Title = "Processor Time - " + processName;
            }
         }
      }

      public CpuUsageVM()
      {
         Title = "Processor Time";
      }

      public void Update()
      {
         Changed(() => Data);
         PushUpdates();
      }
   }
}
