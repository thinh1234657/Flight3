namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANBAY")]
    public partial class SANBAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANBAY()
        {
            TUYENBAYs = new HashSet<TUYENBAY>();
        }

        [Key]
        [StringLength(50)]
        public string MaSanBay { get; set; }

        [StringLength(50)]
        public string TenSanBay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUYENBAY> TUYENBAYs { get; set; }
    }
}
