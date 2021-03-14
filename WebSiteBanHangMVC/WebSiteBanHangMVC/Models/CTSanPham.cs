namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTSanPham")]
    public partial class CTSanPham
    {
        public int CTSanPhamID { get; set; }

        public int? SanPhamID { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(200)]
        public string AnhSanPham { get; set; }

        [StringLength(300)]
        public string ChiTiet { get; set; }

        public int? GiamGia { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
