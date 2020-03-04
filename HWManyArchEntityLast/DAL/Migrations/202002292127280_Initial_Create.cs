namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameDetail = c.String(),
                        Number = c.Int(nullable: false),
                        CarsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarsId, cascadeDelete: true)
                .Index(t => t.CarsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "CarsId", "dbo.Cars");
            DropIndex("dbo.Details", new[] { "CarsId" });
            DropTable("dbo.Details");
            DropTable("dbo.Cars");
        }
    }
}
