namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoSanPham")]
    public partial class LoSanPham
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoSanPhamID { get; set; }

        public int? PhanLoaiSanPhamID { get; set; }

        public int? NhapKhoID { get; set; }

        [StringLength(100)]
        public string SoSerie { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual NhapKho NhapKho { get; set; }

        public virtual PhanLoaiSanPham PhanLoaiSanPham { get; set; }
    }
}
