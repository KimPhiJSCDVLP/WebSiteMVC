namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucSanPham")]
    public partial class DanhMucSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucSanPham()
        {
            PhanLoaiSanPhams = new HashSet<PhanLoaiSanPham>();
        }

        public int DanhMucSanPhamID { get; set; }

        public int? DanhMucSanPhamPID { get; set; }

        [StringLength(100)]
        public string TenDanhMucSanPham { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public bool? Status { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        public bool? LaDoNam { get; set; }

        public bool? LaDoNu { get; set; }

        public bool? LaDoTreEm { get; set; }

        public virtual LoaiDanhMucSanPham LoaiDanhMucSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanLoaiSanPham> PhanLoaiSanPhams { get; set; }
    }
}
