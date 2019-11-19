namespace SearchName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hhhhhhh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientAddresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ClientAdd = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Dob = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientAddresses", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientAddresses", new[] { "ClientId" });
            DropTable("dbo.Clients");
            DropTable("dbo.ClientAddresses");
        }
    }
}
