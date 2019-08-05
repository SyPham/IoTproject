using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoT.Models
{
    public class CycleTimeViewModel
    {
        public double? RealTimeCycleTime { get; set; }
        public double? AverageTimeCycleTime { get; set; }
        public decimal? Availability { get; set; }
        public double? MinRealTime { get; set; }
    }
}