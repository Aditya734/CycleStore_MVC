namespace StoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_BikeType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BikeTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cycles", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cycles", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cycles", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Cycles", "BikeTypeId_Id", c => c.Byte());
            AlterColumn("dbo.Cycles", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Cycles", "BikeTypeId_Id");
            AddForeignKey("dbo.Cycles", "BikeTypeId_Id", "dbo.BikeTypes", "Id");
            DropColumn("dbo.Cycles", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cycles", "Type", c => c.String());
            DropForeignKey("dbo.Cycles", "BikeTypeId_Id", "dbo.BikeTypes");
            DropIndex("dbo.Cycles", new[] { "BikeTypeId_Id" });
            AlterColumn("dbo.Cycles", "Name", c => c.String());
            DropColumn("dbo.Cycles", "BikeTypeId_Id");
            DropColumn("dbo.Cycles", "NumberInStock");
            DropColumn("dbo.Cycles", "ReleaseDate");
            DropColumn("dbo.Cycles", "DateAdded");
            DropTable("dbo.BikeTypes");
        }
    }
}
