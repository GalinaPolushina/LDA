namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Flowering_List
    {
        [Key]
        public int FlowerList_ID { get; set; }

        public int FTB_ID { get; set; }

        public int Plant_ID { get; set; }

        public int FTE_ID { get; set; }

        public virtual Flowering_Beginning Flowering_Beginning { get; set; }

        public virtual Flowering_Ending Flowering_Ending { get; set; }

        public virtual Plant Plant { get; set; }
    }
}
