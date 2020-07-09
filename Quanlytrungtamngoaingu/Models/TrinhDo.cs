namespace Quanlytrungtamngoaingu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrinhDo")]
    public partial class TrinhDo
    {
        [Key]
        [StringLength(10)]
        public string Matd { get; set; }

        [StringLength(10)]
        public string Mann { get; set; }

        [StringLength(50)]
        public string Tentd { get; set; }

        public virtual NgonNgu NgonNgu { get; set; }
    }
}
