namespace AOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondfinal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Country", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Country", c => c.String());
        }
    }
}
