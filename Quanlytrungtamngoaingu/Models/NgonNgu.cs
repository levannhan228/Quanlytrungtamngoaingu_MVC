namespace Quanlytrungtamngoaingu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NgonNgu")]
    public partial class NgonNgu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NgonNgu()
        {
            KhoaHocs = new HashSet<KhoaHoc>();
            TrinhDoes = new HashSet<TrinhDo>();
        }

        [Key]
        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Mã ngôn ngữ")]
        [StringLength(10)]

        public string Mann { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
        [Display(Name = "Tên ngôn ngữ")]
        [StringLength(50)]
        public string Tennn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrinhDo> TrinhDoes { get; set; }
    }
}
