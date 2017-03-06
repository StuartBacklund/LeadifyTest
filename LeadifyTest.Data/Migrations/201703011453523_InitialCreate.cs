namespace LeadifyTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tblContact",
                c => new
                {
                    contactId = c.Guid(nullable: false),
                    firstname = c.String(),
                    lastname = c.String(),
                    cellphone = c.String(),
                    email = c.String(),
                })
                .PrimaryKey(t => t.contactId);
        }

        public override void Down()
        {
            DropTable("tblContact");
        }
    }
}