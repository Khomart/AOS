namespace AOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second_plus_small_change : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "OrganizationCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "OrganizationCategory", c => c.Int(nullable: false));
        }
    }
}
