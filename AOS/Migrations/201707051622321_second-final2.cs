namespace AOS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondfinal2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Admins", name: "UserLinkId", newName: "UserID");
            RenameColumn(table: "dbo.Operators", name: "UserLinkId", newName: "UserID");
            RenameColumn(table: "dbo.States", name: "UserLinkId", newName: "UserID");
            RenameIndex(table: "dbo.Admins", name: "IX_UserLinkId", newName: "IX_UserID");
            RenameIndex(table: "dbo.Operators", name: "IX_UserLinkId", newName: "IX_UserID");
            RenameIndex(table: "dbo.States", name: "IX_UserLinkId", newName: "IX_UserID");
            DropColumn("dbo.Admins", "FirstName");
            DropColumn("dbo.Admins", "SecondName");
            DropColumn("dbo.Operators", "FirstName");
            DropColumn("dbo.Operators", "SecondName");
            DropColumn("dbo.States", "StateID");
            DropColumn("dbo.States", "Name");
            DropColumn("dbo.States", "Short");
            DropColumn("dbo.States", "FirstName");
            DropColumn("dbo.States", "SecondName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.States", "SecondName", c => c.String(nullable: false));
            AddColumn("dbo.States", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.States", "Short", c => c.String());
            AddColumn("dbo.States", "Name", c => c.String());
            AddColumn("dbo.States", "StateID", c => c.Int(nullable: false));
            AddColumn("dbo.Operators", "SecondName", c => c.String(nullable: false));
            AddColumn("dbo.Operators", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "SecondName", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "FirstName", c => c.String(nullable: false));
            RenameIndex(table: "dbo.States", name: "IX_UserID", newName: "IX_UserLinkId");
            RenameIndex(table: "dbo.Operators", name: "IX_UserID", newName: "IX_UserLinkId");
            RenameIndex(table: "dbo.Admins", name: "IX_UserID", newName: "IX_UserLinkId");
            RenameColumn(table: "dbo.States", name: "UserID", newName: "UserLinkId");
            RenameColumn(table: "dbo.Operators", name: "UserID", newName: "UserLinkId");
            RenameColumn(table: "dbo.Admins", name: "UserID", newName: "UserLinkId");
        }
    }
}
