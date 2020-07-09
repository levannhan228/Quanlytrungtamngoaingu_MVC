namespace Quanlytrungtamngoaingu.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TTNNContext : DbContext
    {
        public TTNNContext()
            : base("name=TTNN")
        {
        }

        public virtual DbSet<ChiTietDangKyHoc> ChiTietDangKyHocs { get; set; }
        public virtual DbSet<DangKyHoc> DangKyHocs { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<NgonNgu> NgonNgus { get; set; }
        public virtual DbSet<TrinhDo> TrinhDoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ChiTietDangKyHoc>()
                .Property(e => e.Makh)
                .IsFixedLength();

            //modelBuilder.Entity<ChiTietDangKyHoc>()
            //    .HasMany(E => E.DangKyHoc)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<DangKyHoc>()
            //    .Property(e => e.Makh)
            //    .IsFixedLength();

            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.Magv)
                .IsFixedLength();

            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.Diachigv)
                .IsFixedLength();

            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.Makh)
                .IsFixedLength();

            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.Mann)
                .IsFixedLength();

            modelBuilder.Entity<KhoaHoc>()
                .Property(e => e.Magv)
                .IsFixedLength();

            modelBuilder.Entity<NgonNgu>()
                .Property(e => e.Mann)
                .IsFixedLength();

            modelBuilder.Entity<TrinhDo>()
                .Property(e => e.Matd)
                .IsFixedLength();

            modelBuilder.Entity<TrinhDo>()
                .Property(e => e.Mann)
                .IsFixedLength();
        }

      
    }
}
