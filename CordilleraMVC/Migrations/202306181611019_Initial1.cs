namespace CordilleraMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Producto", "Orden_OrdenId", "dbo.Orden");
            DropIndex("dbo.Producto", new[] { "Orden_OrdenId" });
            CreateTable(
                "dbo.ProductoOrden",
                c => new
                    {
                        Producto_ProductoId = c.Int(nullable: false),
                        Orden_OrdenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Producto_ProductoId, t.Orden_OrdenId })
                .ForeignKey("dbo.Producto", t => t.Producto_ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Orden", t => t.Orden_OrdenId, cascadeDelete: true)
                .Index(t => t.Producto_ProductoId)
                .Index(t => t.Orden_OrdenId);
            
            DropColumn("dbo.Producto", "Orden_OrdenId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producto", "Orden_OrdenId", c => c.Int());
            DropForeignKey("dbo.ProductoOrden", "Orden_OrdenId", "dbo.Orden");
            DropForeignKey("dbo.ProductoOrden", "Producto_ProductoId", "dbo.Producto");
            DropIndex("dbo.ProductoOrden", new[] { "Orden_OrdenId" });
            DropIndex("dbo.ProductoOrden", new[] { "Producto_ProductoId" });
            DropTable("dbo.ProductoOrden");
            CreateIndex("dbo.Producto", "Orden_OrdenId");
            AddForeignKey("dbo.Producto", "Orden_OrdenId", "dbo.Orden", "OrdenId");
        }
    }
}
