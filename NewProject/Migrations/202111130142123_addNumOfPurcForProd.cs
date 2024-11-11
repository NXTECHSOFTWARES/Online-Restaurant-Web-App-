namespace NewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumOfPurcForProd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Product", "numOfPurchase", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Product", "numOfPurchase");
        }
    }
}
