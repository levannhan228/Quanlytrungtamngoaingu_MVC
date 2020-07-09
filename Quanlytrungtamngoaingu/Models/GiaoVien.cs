namespace Quanlytrungtamngoaingu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaoVien")]
    public partial class GiaoVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaoVien()
        {
            KhoaHocs = new HashSet<KhoaHoc>();
        }

        [Key]
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Mã giảng viên")]
        [StringLength(10)]
        public string Magv { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Tên giảng viên")]
        [StringLength(50)]
        public string Tengv { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Địa Chỉ")]

        public string Diachigv { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Điện Thoại")]
        public string Dienthoaigv { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Ngày Sinh")]
        [StringLength(50)]
        public string Ngaysinhgv { get; set; }

        [Display(Name = "Hình Ảnh")]
        [StringLength(50)]
        public string images { get; set; }

        [Display(Name = "Giới Tính")]
        [StringLength(50)]
        public string Gioitinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
