namespace IoT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Arduino")]
    public partial class Arduino
    {
        public int ArduinoID { get; set; }

        public int? ADIndex { get; set; }

        public DateTime? DataTime { get; set; }

        public int? Seq { get; set; }
    }
}
