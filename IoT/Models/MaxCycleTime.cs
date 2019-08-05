namespace IoT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaxCycleTime")]
    public partial class MaxCycleTime
    {
        public int ID { get; set; }

        [StringLength(10)]
        public string Station { get; set; }

        public double? Value { get; set; }
    }
}
