namespace AOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.States", name: "UserID", newName: "UserLinkId");
            RenameIndex(table: "dbo.States", name: "IX_UserID", newName: "IX_UserLinkId");
            AddColumn("dbo.Admins", "UserLinkId", c => c.Int(nullable: false));
            AddColumn("dbo.Operators", "UserLinkId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Title", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Language", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "OrganizationCategory", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "OrganizationName", c => c.String());
            AddColumn("dbo.AspNetUsers", "OrganizationType", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "JobTitle", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "PostalCode", c => c.String());
            AlterColumn("dbo.Admins", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "SecondName", c => c.String(nullable: false));
            AlterColumn("dbo.Operators", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Operators", "SecondName", c => c.String(nullable: false));
            AlterColumn("dbo.States", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.States", "SecondName", c => c.String(nullable: false));
            CreateIndex("dbo.Admins", "UserLinkId");
            CreateIndex("dbo.Operators", "UserLinkId");
            AddForeignKey("dbo.Admins", "UserLinkId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Operators", "UserLinkId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operators", "UserLinkId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Admins", "UserLinkId", "dbo.AspNetUsers");
            DropIndex("dbo.Operators", new[] { "UserLinkId" });
            DropIndex("dbo.Admins", new[] { "UserLinkId" });
            AlterColumn("dbo.States", "SecondName", c => c.String());
            AlterColumn("dbo.States", "FirstName", c => c.String());
            AlterColumn("dbo.Operators", "SecondName", c => c.String());
            AlterColumn("dbo.Operators", "FirstName", c => c.String());
            AlterColumn("dbo.Admins", "SecondName", c => c.String());
            AlterColumn("dbo.Admins", "FirstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "PostalCode");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "JobTitle");
            DropColumn("dbo.AspNetUsers", "OrganizationType");
            DropColumn("dbo.AspNetUsers", "OrganizationName");
            DropColumn("dbo.AspNetUsers", "OrganizationCategory");
            DropColumn("dbo.AspNetUsers", "Language");
            DropColumn("dbo.AspNetUsers", "Title");
            DropColumn("dbo.Operators", "UserLinkId");
            DropColumn("dbo.Admins", "UserLinkId");
            RenameIndex(table: "dbo.States", name: "IX_UserLinkId", newName: "IX_UserID");
            RenameColumn(table: "dbo.States", name: "UserLinkId", newName: "UserID");
        }
    }
}
