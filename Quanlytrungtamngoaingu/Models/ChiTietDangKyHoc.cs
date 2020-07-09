namespace Quanlytrungtamngoaingu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDangKyHoc")]
    public partial class ChiTietDangKyHoc
    {
        public ChiTietDangKyHoc()
        {
            DangKyHoc = new HashSet<DangKyHoc>();
        }
        [Key, Column(Order = 0)]
        [Display(Name = "Mã đăng ký")]
        public int? Madangky { get; set; }
        [Key, Column(Order = 1)]
        [Display(Name = "Mã khóa học")]
        [StringLength(10)]
        public string Makh { get; set; }

        public int? Giaban { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyHoc> DangKyHoc { get; set; }
    }
}
