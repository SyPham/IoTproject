namespace IoT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CycleTime")]
    public partial class CycleTime
    {
        public int ID { get; set; }
        public string ArduinoID { get; set; }
        public double? RealTimeCycleTime { get; set; }
        public DateTime? TimeRevCycleTime { get; set; }
    }
}
