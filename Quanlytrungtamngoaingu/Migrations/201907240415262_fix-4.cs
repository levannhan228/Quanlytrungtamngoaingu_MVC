namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhoaHoc", "AnhBia", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhoaHoc", "AnhBia", c => c.String());
        }
    }
}
