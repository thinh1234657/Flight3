namespace Flight.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            HOADONs = new HashSet<HOADON>();
            PHIEUDATCHOes = new HashSet<PHIEUDATCHO>();
            VECHUYENBAYs = new HashSet<VECHUYENBAY>();
        }

        [Key]
        [StringLength(50)]
        public string CMND { get; set; }

        
        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [DisplayName("Số điện thoại")]
        [StringLength(50)]
        public string DienThoai { get; set; }

        [Required(ErrorMessage = "Vui lòng điền mật khẩu ")]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        [StringLength(50)]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATCHO> PHIEUDATCHOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VECHUYENBAY> VECHUYENBAYs { get; set; }
    }
}
