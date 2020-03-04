namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Last_Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Details", "NameDetail", c => c.String(maxLength: 20));
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Manufacturers", "Name", c => c.String());
            AlterColumn("dbo.Details", "NameDetail", c => c.String());
            AlterColumn("dbo.Cars", "Name", c => c.String());
        }
    }
}
