namespace Quanlytrungtamngoaingu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocVien")]
    public partial class HocVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocVien()
        {
            DangKyHocs = new HashSet<DangKyHoc>();
        }

        [Key]
        [Display(Name = "Mã Học Viên")]
        public int Mahv { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Họ và Tên")]
        [StringLength(50)]
        public string Hotenhv { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Tài Khoản")]
        [StringLength(50)]
        public string Taikhoan { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Mật Khẩu")]
        [DataType(DataType.Password)]
        [StringLength(50,MinimumLength = 6,ErrorMessage ="Mật khẩu phải có ít nhất 6 ký tự")]
        public string Matkhau { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Vui lòng nhập đúng Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Địa Chỉ")]
        [StringLength(50)]
        public string Diachihv { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Điện Thoại")]
        [Phone(ErrorMessage ="Vui lòng nhập đúng số điện thoại")]
        [StringLength(50)]
        public string Dienthoaihv { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Giới Tính")]
        [StringLength(50)]
        public string Gioitinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Ngày Sinh")]
        [StringLength(50)]
        public string Ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyHoc> DangKyHocs { get; set; }
    }
}
