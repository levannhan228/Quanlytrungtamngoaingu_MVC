namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changevaludation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GiaoVien", "Tengv", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.GiaoVien", "Diachigv", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.GiaoVien", "Dienthoaigv", c => c.String(nullable: false));
            AlterColumn("dbo.GiaoVien", "Ngaysinhgv", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GiaoVien", "Ngaysinhgv", c => c.String(maxLength: 50));
            AlterColumn("dbo.GiaoVien", "Dienthoaigv", c => c.String());
            AlterColumn("dbo.GiaoVien", "Diachigv", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.GiaoVien", "Tengv", c => c.String(maxLength: 50));
        }
    }
}
