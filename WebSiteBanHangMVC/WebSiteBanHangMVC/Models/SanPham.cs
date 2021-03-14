namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTSanPhams = new HashSet<CTSanPham>();
            SanPhamDonHangs = new HashSet<SanPhamDonHang>();
            ThongSoSanPhams = new HashSet<ThongSoSanPham>();
        }

        public int SanPhamID { get; set; }

        public int? LoaiSanPhamID { get; set; }

        [StringLength(100)]
        public string TenSanPham { get; set; }

        [StringLength(200)]
        public string ThongTinSanPham { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(200)]
        public string AnhSanPham { get; set; }

        [StringLength(10)]
        public string MaSanPham { get; set; }

        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }

        public double? GiaSanPham { get; set; }

        [Column(TypeName = "xml")]
        public string ThemHinhAnh { get; set; }

        public bool? Hot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTSanPham> CTSanPhams { get; set; }

        public virtual PhanLoaiSanPham PhanLoaiSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPhamDonHang> SanPhamDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongSoSanPham> ThongSoSanPhams { get; set; }
    }
}
