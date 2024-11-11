namespace NewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addItemDesc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_Product", "ProductDestription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_Product", "ProductDestription");
        }
    }
}
