declare var Chart: any;

class LiveChartVM {

   // Local observable to display current data value.
   _currentValue: number = 0;

   // On data update, update the chart.
   updateChart(iItem, iElement) {
      var vm: any = this;

      var data = vm.Data();
      if (data == null)
         return;

      if (vm._chart == null) {
         vm._chart = this.createChart(data, iElement);
         vm._counter = 0;
      }
      else {
         vm._chart.addData([data], "");
         vm._counter++;
         if (vm._counter > 30)
            // Remove the oldest data.
            vm._chart.removeData();
      }

      vm._currentValue(data);
      vm.Data(null);
   }

   // Create the chart with ChartJS.
   createChart(iData, iElement) {
      var chartData = {
         labels: [],
         datasets: [{
            data: iData,
            fillColor: "rgba(217,237,245,0.2)",
            strokeColor: "#9acfea",
            pointColor: "#9acfea",
            pointStrokeColor: "#fff"
         }]
      };

      return new Chart(iElement.getContext('2d')).Line(chartData, { responsive: true, animation: false });
   }
}