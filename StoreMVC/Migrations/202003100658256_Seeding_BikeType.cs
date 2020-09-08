namespace StoreMVC.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class Seeding_BikeType : DbMigration
	{
		public override void Up()
		{
			Sql("Insert into BikeTypes Values (1,'Mountain Bike')");
			Sql("Insert into BikeTypes Values (2,'Road Bike')");
			Sql("Insert into BikeTypes Values (3,'Triathlon Bike')");
			Sql("Insert into BikeTypes Values (4,'BMX Bike')");
			Sql("Insert into BikeTypes Values (5,'Commuting Bike')");
			Sql("Insert into BikeTypes Values (6,'Cyclocross Bike')");
			Sql("Insert into BikeTypes Values (7,'Folding Bike')");
			Sql("Insert into BikeTypes Values (8,'Kids Bike')");
		}
		
		public override void Down()
		{
		}
	}
}
