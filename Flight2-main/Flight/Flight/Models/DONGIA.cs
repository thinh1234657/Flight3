namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONGIA")]
    public partial class DONGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONGIA()
        {
            VECHUYENBAYs = new HashSet<VECHUYENBAY>();
        }

        [Key]
        [StringLength(50)]
        public string MaDonGia { get; set; }

        public int? USD { get; set; }

        public int? VND { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VECHUYENBAY> VECHUYENBAYs { get; set; }
    }
}
