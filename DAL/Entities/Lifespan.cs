namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lifespan")]
    public partial class Lifespan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lifespan()
        {
            Plants = new HashSet<Plant>();
        }

        [Key]
        public int LS_ID { get; set; }

        [Column("Lifespan")]
        [Required]
        [StringLength(50)]
        public string Lifespan1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plant> Plants { get; set; }
    }
}
