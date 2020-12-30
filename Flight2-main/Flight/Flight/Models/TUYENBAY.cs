namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TUYENBAY")]
    public partial class TUYENBAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TUYENBAY()
        {
            CHUYENBAYs = new HashSet<CHUYENBAY>();
            SANBAYs = new HashSet<SANBAY>();
        }

        [Key]
        [StringLength(50)]
        public string MaTuyenBay { get; set; }

        [StringLength(50)]
        public string MaSanBayDi { get; set; }

        [StringLength(50)]
        public string MaSanBayDen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUYENBAY> CHUYENBAYs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANBAY> SANBAYs { get; set; }
    }
}
