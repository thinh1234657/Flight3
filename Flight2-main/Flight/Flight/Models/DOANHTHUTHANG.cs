namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOANHTHUTHANG")]
    public partial class DOANHTHUTHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOANHTHUTHANG()
        {
            DOANHTHUNAMs = new HashSet<DOANHTHUNAM>();
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(50)]
        public string MaDoanhThuThang { get; set; }

        public int? SoLuongVe { get; set; }

        public int? DoanhThu { get; set; }

        [StringLength(50)]
        public string MaDoanhThuNam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOANHTHUNAM> DOANHTHUNAMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
