namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [StringLength(50)]
        public string MaHoaDon { get; set; }

        public DateTime? NgayHoaDon { get; set; }

        [StringLength(50)]
        public string ThanhTien { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string MaNhanVien { get; set; }

        [StringLength(50)]
        public string MaDoanhThuThang { get; set; }

        public virtual DOANHTHUTHANG DOANHTHUTHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
