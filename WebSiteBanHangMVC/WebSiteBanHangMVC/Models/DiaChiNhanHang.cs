namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiaChiNhanHang")]
    public partial class DiaChiNhanHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiaChiNhanHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        public int DiaChiNhanHangID { get; set; }

        public int? KhachHangID { get; set; }

        public int? ThanhPhoID { get; set; }

        public int? QuanHuyenID { get; set; }

        public int? XqaPhuongID { get; set; }

        [StringLength(200)]
        public string DiaChiChiTiet { get; set; }

        public int? SoDienThoai { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual QuanHuyen QuanHuyen { get; set; }

        public virtual ThanhPho ThanhPho { get; set; }

        public virtual XaPhuong XaPhuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
