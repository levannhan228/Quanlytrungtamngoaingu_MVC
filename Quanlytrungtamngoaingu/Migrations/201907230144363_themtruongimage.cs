namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themtruongimage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KhoaHoc", "Magv", "dbo.GiaoVien");
            DropForeignKey("dbo.KhoaHoc", "Mann", "dbo.NgonNgu");
            DropIndex("dbo.KhoaHoc", new[] { "Mann" });
            DropIndex("dbo.KhoaHoc", new[] { "Magv" });
            AddColumn("dbo.GiaoVien", "images", c => c.String(maxLength: 50));
            AlterColumn("dbo.KhoaHoc", "Tenkhoahoc", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.KhoaHoc", "Giaban", c => c.Int(nullable: false));
            AlterColumn("dbo.KhoaHoc", "Mota", c => c.String(nullable: false));
            AlterColumn("dbo.KhoaHoc", "AnhBia", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.KhoaHoc", "Mann", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.KhoaHoc", "Magv", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            CreateIndex("dbo.KhoaHoc", "Mann");
            CreateIndex("dbo.KhoaHoc", "Magv");
            AddForeignKey("dbo.KhoaHoc", "Magv", "dbo.GiaoVien", "Magv", cascadeDelete: true);
            AddForeignKey("dbo.KhoaHoc", "Mann", "dbo.NgonNgu", "Mann", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KhoaHoc", "Mann", "dbo.NgonNgu");
            DropForeignKey("dbo.KhoaHoc", "Magv", "dbo.GiaoVien");
            DropIndex("dbo.KhoaHoc", new[] { "Magv" });
            DropIndex("dbo.KhoaHoc", new[] { "Mann" });
            AlterColumn("dbo.KhoaHoc", "Magv", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.KhoaHoc", "Mann", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.KhoaHoc", "AnhBia", c => c.String(maxLength: 50));
            AlterColumn("dbo.KhoaHoc", "Mota", c => c.String());
            AlterColumn("dbo.KhoaHoc", "Giaban", c => c.Int());
            AlterColumn("dbo.KhoaHoc", "Tenkhoahoc", c => c.String(maxLength: 50));
            DropColumn("dbo.GiaoVien", "images");
            CreateIndex("dbo.KhoaHoc", "Magv");
            CreateIndex("dbo.KhoaHoc", "Mann");
            AddForeignKey("dbo.KhoaHoc", "Mann", "dbo.NgonNgu", "Mann");
            AddForeignKey("dbo.KhoaHoc", "Magv", "dbo.GiaoVien", "Magv");
        }
    }
}
