namespace StoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALteredCycleType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cycles", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cycles", "Type");
        }
    }
}
