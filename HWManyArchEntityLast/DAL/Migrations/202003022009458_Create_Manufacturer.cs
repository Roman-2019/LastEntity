namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Manufacturer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.Manufacturers(Name) VALUES('Not Selected')");

            AddColumn("dbo.Cars", "ManufacturerId", c => c.Int(nullable: false));
            AddColumn("dbo.Details", "ManufacturerId", c => c.Int(nullable: false));

            Sql("Update dbo.Cars SET ManufacturerId=1");
            Sql("Update dbo.Details SET ManufacturerId=1");

            CreateIndex("dbo.Cars", "ManufacturerId");
            CreateIndex("dbo.Details", "ManufacturerId");
            AddForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Details", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: false);

            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Details", new[] { "ManufacturerId" });
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            DropColumn("dbo.Details", "ManufacturerId");
            DropColumn("dbo.Cars", "ManufacturerId");
            DropTable("dbo.Manufacturers");
        }
    }
}
