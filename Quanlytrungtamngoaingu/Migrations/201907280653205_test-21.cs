namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GiaoVien", "Diachigv", c => c.String(nullable: false, maxLength: 128, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GiaoVien", "Diachigv", c => c.String(nullable: false, maxLength: 50, fixedLength: true));
        }
    }
}
