namespace Quanlytrungtamngoaingu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("KhoaHoc")]
    public partial class KhoaHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoaHoc()
        {
            ChiTietDangKyHocs = new HashSet<ChiTietDangKyHoc>();
            DangKyHocs = new HashSet<DangKyHoc>();
        }

        [Key]
        [StringLength(10)]
        [Required(ErrorMessage ="Vui lòng nhập dữ liệu cho trường này.")]
       
        [Display(Name ="Mã khóa học")]
        public string Makh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Tên khóa học")]
        [StringLength(50)]
        public string Tenkhoahoc { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Học phí")]
        public int? Giaban { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Mô tả")]
        public string Mota { get; set; }

        [MaxLength(255)]
        [Display(Name = "Ảnh minh họa")]
        public string AnhBia { get; set; }

        [Display(Name = "Thời gian học")]
        [StringLength(50)]
        public string Thoigianhoc { get; set; }

        [Display(Name = "Sĩ số")]
        public int? Siso { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Mã ngôn ngữ")]
        [StringLength(10)]
        public string Mann { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Mã giáo viên")]
        [StringLength(10)]
        public string Magv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDangKyHoc> ChiTietDangKyHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyHoc> DangKyHocs { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        public virtual NgonNgu NgonNgu { get; set; }
    }
}
