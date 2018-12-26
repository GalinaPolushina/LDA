namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fert_List
    {
        [Key]
        public int FList_ID { get; set; }

        public int Fert_ID { get; set; }

        public int Plant_ID { get; set; }

        public virtual Fertilizer Fertilizer { get; set; }

        public virtual Plant Plant { get; set; }
    }
}
