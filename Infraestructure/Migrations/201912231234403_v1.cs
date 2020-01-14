namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Stock = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.SalesInvoceDetails",
                c => new
                    {
                        SalesInvoceDetailID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Single(nullable: false),
                        SalesInvoceID = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesInvoceDetailID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.SalesInvoces", t => t.SalesInvoceID, cascadeDelete: true)
                .Index(t => t.SalesInvoceID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.SalesInvoces",
                c => new
                    {
                        SalesInvoceID = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Payed = c.Boolean(nullable: false),
                        discount = c.Int(nullable: false),
                        Reason = c.String(),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SellerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesInvoceID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.SellerID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SellerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesInvoces", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.SalesInvoceDetails", "SalesInvoceID", "dbo.SalesInvoces");
            DropForeignKey("dbo.SalesInvoces", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.SalesInvoceDetails", "ProductID", "dbo.Products");
            DropIndex("dbo.SalesInvoces", new[] { "SellerID" });
            DropIndex("dbo.SalesInvoces", new[] { "CustomerID" });
            DropIndex("dbo.SalesInvoceDetails", new[] { "ProductID" });
            DropIndex("dbo.SalesInvoceDetails", new[] { "SalesInvoceID" });
            DropTable("dbo.Sellers");
            DropTable("dbo.SalesInvoces");
            DropTable("dbo.SalesInvoceDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
