namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VECHUYENBAY")]
    public partial class VECHUYENBAY
    {
        [Key]
        [StringLength(50)]
        public string MaVeChuyenBay { get; set; }

        public int? TinhTrangVe { get; set; }

        [StringLength(50)]
        public string MaDonGia { get; set; }

        [StringLength(50)]
        public string MaHangVe { get; set; }

        [StringLength(50)]
        public string MaChuyenBay { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        public virtual CHUYENBAY CHUYENBAY { get; set; }

        public virtual DONGIA DONGIA { get; set; }

        public virtual HANGVE HANGVE { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
