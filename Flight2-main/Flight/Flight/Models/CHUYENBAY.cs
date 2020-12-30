namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUYENBAY")]
    public partial class CHUYENBAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUYENBAY()
        {
            VECHUYENBAYs = new HashSet<VECHUYENBAY>();
        }

        [Key]
        [StringLength(50)]
        public string MaChuyenBay { get; set; }

        public DateTime? NgayGio { get; set; }

        public TimeSpan? ThoiGianBay { get; set; }

        public int? SoLuongGheHang1 { get; set; }

        public int? SoLuongGheHang2 { get; set; }

        [StringLength(50)]
        public string MaChiTietChuyenBay { get; set; }

        [StringLength(50)]
        public string MaTuyenBay { get; set; }

        [StringLength(50)]
        public string MaMayBay { get; set; }

        public virtual CHITIETCHUYENBAY CHITIETCHUYENBAY { get; set; }

        public virtual MAYBAY MAYBAY { get; set; }

        public virtual TUYENBAY TUYENBAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VECHUYENBAY> VECHUYENBAYs { get; set; }
    }
}
