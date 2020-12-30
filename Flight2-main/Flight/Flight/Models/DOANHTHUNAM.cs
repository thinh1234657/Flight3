namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOANHTHUNAM")]
    public partial class DOANHTHUNAM
    {
        [Key]
        [StringLength(50)]
        public string MaDoanhThuNam { get; set; }

        public int? SoLuongVe { get; set; }

        public int? DoanhThu { get; set; }

        [StringLength(50)]
        public string MaDoanhThuThang { get; set; }

        public virtual DOANHTHUTHANG DOANHTHUTHANG { get; set; }
    }
}
