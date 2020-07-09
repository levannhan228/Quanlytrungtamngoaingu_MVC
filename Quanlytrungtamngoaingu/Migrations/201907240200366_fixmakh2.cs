namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixmakh2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DangKyHoc", "Madangky", "dbo.ChiTietDangKyHoc");
            DropIndex("dbo.DangKyHoc", new[] { "Madangky" });
            CreateTable(
                "dbo.DangKyHocChiTietDangKyHocs",
                c => new
                    {
                        DangKyHoc_Madangky = c.Int(nullable: false),
                        ChiTietDangKyHoc_Madangky = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DangKyHoc_Madangky, t.ChiTietDangKyHoc_Madangky })
                .ForeignKey("dbo.DangKyHoc", t => t.DangKyHoc_Madangky, cascadeDelete: true)
                .ForeignKey("dbo.ChiTietDangKyHoc", t => t.ChiTietDangKyHoc_Madangky, cascadeDelete: true)
                .Index(t => t.DangKyHoc_Madangky)
                .Index(t => t.ChiTietDangKyHoc_Madangky);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DangKyHocChiTietDangKyHocs", "ChiTietDangKyHoc_Madangky", "dbo.ChiTietDangKyHoc");
            DropForeignKey("dbo.DangKyHocChiTietDangKyHocs", "DangKyHoc_Madangky", "dbo.DangKyHoc");
            DropIndex("dbo.DangKyHocChiTietDangKyHocs", new[] { "ChiTietDangKyHoc_Madangky" });
            DropIndex("dbo.DangKyHocChiTietDangKyHocs", new[] { "DangKyHoc_Madangky" });
            DropTable("dbo.DangKyHocChiTietDangKyHocs");
            CreateIndex("dbo.DangKyHoc", "Madangky");
            AddForeignKey("dbo.DangKyHoc", "Madangky", "dbo.ChiTietDangKyHoc", "Madangky");
        }
    }
}
