namespace StoreMVC.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class UpdatingMembershipTypeTable : DbMigration
	{
		public override void Up()
		{
			Sql("update Membershiptypes set Name = 'Pay as You Go' where signUpFee = 0");
			Sql("update Membershiptypes set Name = 'Monthly' where signUpFee = 30");
			Sql("update Membershiptypes set Name = 'Quaterly' where signUpFee = 90");
			Sql("update Membershiptypes set Name = 'Annual' where signUpFee = 700");
		}
		
		public override void Down()
		{
		}
	}
}
