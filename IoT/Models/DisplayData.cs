using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IoT.Models
{
    public class DisplayData
    {
        public int ID { get; set; }
        public string ArduinoID { get; set; }
        public double TotalTime { get; set; }
        public double Count { get; set; }
        public double RealTime { get; set; }
        public double MinRealTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}