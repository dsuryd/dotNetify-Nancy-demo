using System;
using System.Timers;
using DotNetify;

namespace DemoLibrary
{
   public class DashboardVM : BaseVM
   {
      private Timer _timer;
      private MemoryUsageVM _memoryUsageVM = new MemoryUsageVM();
      private CpuUsageVM _cpuUsageVM = new CpuUsageVM();
      private ProcessVM _processVM = new ProcessVM();

      public double[,] Data
      {
         get { return Get<double[,]>(); }
         set { Set(value); }
      }

      /// <summary>
      /// Constructor.
      /// </summary>
      public DashboardVM()
      {
         _processVM.Selected += (sender, e) =>
         {
            _cpuUsageVM.ProcessId = e;
            _memoryUsageVM.ProcessId = e;
         };

         // Run a timer every second to update the chart.
         _timer = new Timer(1000);
         _timer.Elapsed += Timer_Elapsed;
         _timer.Start();
      }

      public override void Dispose()
      {
         _timer.Stop();
         _timer.Elapsed -= Timer_Elapsed;
         base.Dispose();
      }

      public override BaseVM GetSubVM(string vMTypeName)
      {
         if (vMTypeName == typeof(CpuUsageVM).Name)
            return _cpuUsageVM;
         else if (vMTypeName == typeof(MemoryUsageVM).Name)
            return _memoryUsageVM;
         else if (vMTypeName == typeof(ProcessVM).Name)
            return _processVM;

         return base.GetSubVM(vMTypeName);
      }

      private void Timer_Elapsed(object sender, ElapsedEventArgs e)
      {
         _memoryUsageVM.Update();
         _cpuUsageVM.Update();
      }
   }
}
