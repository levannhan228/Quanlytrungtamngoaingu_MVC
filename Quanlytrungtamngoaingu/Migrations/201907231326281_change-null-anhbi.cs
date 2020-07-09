namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenullanhbi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhoaHoc", "AnhBia", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhoaHoc", "AnhBia", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
