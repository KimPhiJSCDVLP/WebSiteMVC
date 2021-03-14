namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPhamDonHang")]
    public partial class SanPhamDonHang
    {
        public int SanPhamDonHangID { get; set; }

        public int? SanPhamID { get; set; }

        public int? DonHangID { get; set; }

        [StringLength(300)]
        public string GhiChu { get; set; }

        public int? SoLuong { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
