namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HANGVE")]
    public partial class HANGVE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANGVE()
        {
            VECHUYENBAYs = new HashSet<VECHUYENBAY>();
            PHIEUDATCHOes = new HashSet<PHIEUDATCHO>();
        }

        [Key]
        [StringLength(50)]
        public string MaHangVe { get; set; }

        [StringLength(50)]
        public string TenHangVe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VECHUYENBAY> VECHUYENBAYs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATCHO> PHIEUDATCHOes { get; set; }
    }
}
