namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plant")]
    public partial class Plant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plant()
        {
            Flowering_List = new HashSet<Flowering_List>();
            Plantings = new HashSet<Planting>();
        }

        [Key]
        public int Plant_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Plant_Name { get; set; }

        public string Cutting_Comment { get; set; }

        public string Fert_Comment { get; set; }

        public string Watering_Comment { get; set; }

        public string Image { get; set; }

        public int Fert_ID { get; set; }

        public int ST_ID { get; set; }

        public int LS_ID { get; set; }

        public int LF_ID { get; set; }

        public virtual Fertilizer Fertilizer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flowering_List> Flowering_List { get; set; }

        public virtual Life_Form Life_Form { get; set; }

        public virtual Lifespan Lifespan { get; set; }

        public virtual Soil_Type Soil_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Planting> Plantings { get; set; }
    }
}
