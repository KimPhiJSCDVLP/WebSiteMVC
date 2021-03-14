namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            SanPhamDonHangs = new HashSet<SanPhamDonHang>();
        }

        public int DonHangID { get; set; }

        public int? NhanVienID { get; set; }

        public int? KhachHangID { get; set; }

        public int? DiaChiNhanHangID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuat { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public double? GiaTriDonHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhan { get; set; }

        public bool? Status { get; set; }

        [StringLength(500)]
        public string DiaChiNhanHangChiTiet { get; set; }

        public virtual DiaChiNhanHang DiaChiNhanHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPhamDonHang> SanPhamDonHangs { get; set; }
    }
}
