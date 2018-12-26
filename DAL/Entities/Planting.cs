namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Planting")]
    public partial class Planting
    {
        [Key]
        public int Planting_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Planting_Date { get; set; }

        public string Planting_Place { get; set; }

        public int Status_ID { get; set; }

        public int Plant_ID { get; set; }

        public int Project_ID { get; set; }

        public virtual Plant Plant { get; set; }

        public virtual Project Project { get; set; }

        public virtual Status Status { get; set; }
    }
}
