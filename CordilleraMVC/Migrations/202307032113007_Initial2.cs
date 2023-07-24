namespace CordilleraMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProductoOrden", name: "Producto_ProductoId", newName: "ProductoId");
            RenameColumn(table: "dbo.ProductoOrden", name: "Orden_OrdenId", newName: "OrdenId");
            RenameIndex(table: "dbo.ProductoOrden", name: "IX_Producto_ProductoId", newName: "IX_ProductoId");
            RenameIndex(table: "dbo.ProductoOrden", name: "IX_Orden_OrdenId", newName: "IX_OrdenId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProductoOrden", name: "IX_OrdenId", newName: "IX_Orden_OrdenId");
            RenameIndex(table: "dbo.ProductoOrden", name: "IX_ProductoId", newName: "IX_Producto_ProductoId");
            RenameColumn(table: "dbo.ProductoOrden", name: "OrdenId", newName: "Orden_OrdenId");
            RenameColumn(table: "dbo.ProductoOrden", name: "ProductoId", newName: "Producto_ProductoId");
        }
    }
}
