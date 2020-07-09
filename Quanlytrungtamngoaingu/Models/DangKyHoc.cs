namespace Quanlytrungtamngoaingu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DangKyHoc")]
    public partial class DangKyHoc
    {
        public DangKyHoc()
        {
            ChiTietDangKyHoc = new HashSet<ChiTietDangKyHoc>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "Mã đăng ký")]
        public int Madangky { get; set; }

        //[StringLength(10)]
        //[Display(Name = "Mã khóa học")]
        //public string Makh { get; set; }

        [Display(Name = "Đã thanh toán")]
        public int? Dathanhtoan { get; set; }

        [Display(Name = "Ngày đăng ký")]
        [StringLength(50)]
        public string Ngaydangky { get; set; }

        [Display(Name = "Lịch học")]
        [StringLength(50)]
        public string Lichhoc { get; set; }

        [Display(Name = "Mã học viên")]
        public int? Mahv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<ChiTietDangKyHoc>  ChiTietDangKyHoc { get; set; }

        public virtual HocVien HocVien { get; set; }

        //public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
