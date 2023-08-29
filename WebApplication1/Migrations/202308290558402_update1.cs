namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Catagories");
            AddColumn("dbo.Catagories", "Product_ProductId", c => c.Int());
            AddColumn("dbo.Products", "Catagory_CatagoryId", c => c.Int());
            CreateIndex("dbo.Catagories", "Product_ProductId");
            CreateIndex("dbo.Products", "Catagory_CatagoryId");
            AddForeignKey("dbo.Catagories", "Product_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Products", "Catagory_CatagoryId", "dbo.Catagories", "CatagoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Catagory_CatagoryId", "dbo.Catagories");
            DropForeignKey("dbo.Catagories", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Products", new[] { "Catagory_CatagoryId" });
            DropIndex("dbo.Catagories", new[] { "Product_ProductId" });
            DropColumn("dbo.Products", "Catagory_CatagoryId");
            DropColumn("dbo.Catagories", "Product_ProductId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Catagories", "CatagoryId", cascadeDelete: true);
        }
    }
}
