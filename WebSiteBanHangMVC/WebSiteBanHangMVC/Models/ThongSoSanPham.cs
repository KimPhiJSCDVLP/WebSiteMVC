namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongSoSanPham")]
    public partial class ThongSoSanPham
    {
        public int ThongSoSanPhamID { get; set; }

        public int? LoaiThongSoID { get; set; }

        public int? SanPhamID { get; set; }

        public double? GiaTri { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public string NoiDung { get; set; }

        public virtual LoaiThongSo LoaiThongSo { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
