namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUDATCHO")]
    public partial class PHIEUDATCHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUDATCHO()
        {
            HANGVEs = new HashSet<HANGVE>();
        }

        [Key]
        [StringLength(50)]
        public string MaPhieuDatCho { get; set; }

        public DateTime? NgayDat { get; set; }

        public int? SoGheDat { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string MaChuyenBay { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HANGVE> HANGVEs { get; set; }
    }
}
