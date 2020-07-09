namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixmakh : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DangKyHoc", name: "Makh", newName: "KhoaHoc_Makh");
            RenameIndex(table: "dbo.DangKyHoc", name: "IX_Makh", newName: "IX_KhoaHoc_Makh");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DangKyHoc", name: "IX_KhoaHoc_Makh", newName: "IX_Makh");
            RenameColumn(table: "dbo.DangKyHoc", name: "KhoaHoc_Makh", newName: "Makh");
        }
    }
}
