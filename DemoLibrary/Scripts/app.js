﻿require.config({
   baseUrl: '/Scripts',
   paths: {
      "jquery": "jquery-1.11.3.min",
      "jquery-ui": "jquery-ui-widget-1.11.4.min",
      "knockout": "knockout-3.4.0",
      "ko-mapping": "knockout.mapping-latest",
      "dotnetify": "dotnetify",
      "signalr": "jquery.signalR-2.2.0.min",
      "signalr-hub": "/signalr/hubs?",
      "chart": "chart.min",
      "live-chart": "CodeBehind/LiveChart",
      "cpu-usage": "CodeBehind/CPUUsage",
      "mem-usage": "CodeBehind/MemoryUsage",
   },
   shim: {
      "jquery": { exports: "$" },
      "knockout": { exports: "ko" },
      "path": { exports: "Path" },
      "signalr": { deps: ["jquery"], exports: "$.connection" },
      "signalr-hub": ["signalr"],
      "live-chart": { deps: ["chart"] },
      "cpu-usage": { deps: ["live-chart"] },
      "mem-usage": { deps: ["live-chart"] }
   }
});

require(['jquery', 'dotnetify', 'cpu-usage', 'mem-usage'], function ($) {
   $(function () {
      dotnetify.debug = true;
   });
});