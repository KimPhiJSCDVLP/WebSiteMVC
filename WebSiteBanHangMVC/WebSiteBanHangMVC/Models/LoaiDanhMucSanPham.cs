namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiDanhMucSanPham")]
    public partial class LoaiDanhMucSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiDanhMucSanPham()
        {
            DanhMucSanPhams = new HashSet<DanhMucSanPham>();
        }

        [Key]
        public int DanhMucSanPhamPID { get; set; }

        [StringLength(50)]
        public string TenLoaiDanhMucSanPham { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhMucSanPham> DanhMucSanPhams { get; set; }
    }
}
