namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETCHUYENBAY")]
    public partial class CHITIETCHUYENBAY
    {
        [Key]
        [StringLength(50)]
        public string MaChiTietChuyenBay { get; set; }

        [Required]
        [StringLength(50)]
        public string MaChuyenBay { get; set; }

        public int? SanBayTrungGian { get; set; }

        public DateTime? ThoiGianDung { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        public virtual CHUYENBAY CHUYENBAY { get; set; }
    }
}
