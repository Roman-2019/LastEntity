namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnInDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Details", "Price", c => c.Int(nullable: false),anonymousArguments:777);
        }
        
        public override void Down()
        {
            DropColumn("dbo.Details", "Price");
        }
    }
}
