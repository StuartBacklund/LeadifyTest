namespace LeadifyTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Contact : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contacts", newName: "tblContact");
            DropPrimaryKey("dbo.tblContact");
            AlterColumn("dbo.tblContact", "firstname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.tblContact", "lastname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.tblContact", "cellphone", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.tblContact", "email", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.tblContact", "contactId");
            DropColumn("dbo.tblContact", "Id");
        }

        public override void Down()
        {
            AddColumn("dbo.tblContact", "Id", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.tblContact");
            AlterColumn("dbo.tblContact", "email", c => c.String());
            AlterColumn("dbo.tblContact", "cellphone", c => c.String());
            AlterColumn("dbo.tblContact", "lastname", c => c.String());
            AlterColumn("dbo.tblContact", "firstname", c => c.String());
            AddPrimaryKey("dbo.tblContact", "Id");
            RenameTable(name: "dbo.tblContact", newName: "Contacts");
        }
    }
}