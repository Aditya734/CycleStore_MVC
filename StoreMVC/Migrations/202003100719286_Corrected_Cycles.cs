namespace StoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corrected_Cycles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cycles", "BikeTypeId_Id", "dbo.BikeTypes");
            DropIndex("dbo.Cycles", new[] { "BikeTypeId_Id" });
            RenameColumn(table: "dbo.Cycles", name: "BikeTypeId_Id", newName: "BikeTypeId");
            AlterColumn("dbo.Cycles", "BikeTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cycles", "BikeTypeId");
            AddForeignKey("dbo.Cycles", "BikeTypeId", "dbo.BikeTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cycles", "BikeTypeId", "dbo.BikeTypes");
            DropIndex("dbo.Cycles", new[] { "BikeTypeId" });
            AlterColumn("dbo.Cycles", "BikeTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Cycles", name: "BikeTypeId", newName: "BikeTypeId_Id");
            CreateIndex("dbo.Cycles", "BikeTypeId_Id");
            AddForeignKey("dbo.Cycles", "BikeTypeId_Id", "dbo.BikeTypes", "Id");
        }
    }
}
