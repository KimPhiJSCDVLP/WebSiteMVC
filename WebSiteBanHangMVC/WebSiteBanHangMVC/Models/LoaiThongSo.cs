namespace WebSiteBanHangMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiThongSo")]
    public partial class LoaiThongSo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiThongSo()
        {
            ThongSoSanPhams = new HashSet<ThongSoSanPham>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoaiThongSoID { get; set; }

        [StringLength(100)]
        public string TenLoaiThongSo { get; set; }

        [StringLength(200)]
        public string DacDiem { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongSoSanPham> ThongSoSanPhams { get; set; }
    }
}
