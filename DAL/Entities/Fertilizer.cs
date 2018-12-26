namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fertilizer")]
    public partial class Fertilizer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fertilizer()
        {
            Fert_List = new HashSet<Fert_List>();
        }

        [Key]
        public int Fert_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Fert_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fert_List> Fert_List { get; set; }
    }
}
