using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using DotNetify;

namespace DemoLibrary
{
   public class ProcessVM : BaseVM
   {
      public class ProcessItem
      {
         public int Id { get; set; }
         public string Name { get; set; }
      }

      public bool IsLoading { get; set; }

      public string SearchString
      {
         get { return Get<string>(); }
         set
         {
            Set(value);
            Changed(() => Processes);
         }
      }

      public List<ProcessItem> Processes
      {
         get
         {
            return Process.GetProcesses()
               .Where(i => String.IsNullOrEmpty(SearchString) || i.ProcessName.ToLower().StartsWith(SearchString.ToLower()))
               .OrderBy(i => i.ProcessName)
               .ToList()
               .ConvertAll(i => new ProcessItem { Id = i.Id, Name = i.ProcessName });
         }
      }

      public int SelectedProcessId
      {
         get { return Get<int>(); }
         set
         {
            Set(value);
            if (Selected != null)
               Selected(this, value);
         }
      }

      public event EventHandler<int> Selected;

      public static string GetProcessInstanceName(int processId)
      {
         foreach (string instanceName in new PerformanceCounterCategory("Process").GetInstanceNames())
         {
            using (PerformanceCounter counter = new PerformanceCounter("Process", "ID Process", instanceName, true))
            {
               if ((int)counter.RawValue == processId)
                  return instanceName;
            }
         }
         return null;
      }
   }
}
