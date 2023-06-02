namespace CordilleraMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 100),
                        Direccion = c.String(nullable: false, maxLength: 200),
                        Ciudad = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Orden",
                c => new
                    {
                        OrdenId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrdenId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleado", t => t.EmpleadoId, cascadeDelete: true)
                .Index(t => t.EmpleadoId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 100),
                        Cargo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false, maxLength: 70),
                        Descripcion = c.String(maxLength: 1000),
                        Precio = c.Double(nullable: false),
                        Orden_OrdenId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.Orden", t => t.Orden_OrdenId)
                .Index(t => t.Orden_OrdenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producto", "Orden_OrdenId", "dbo.Orden");
            DropForeignKey("dbo.Orden", "EmpleadoId", "dbo.Empleado");
            DropForeignKey("dbo.Orden", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Producto", new[] { "Orden_OrdenId" });
            DropIndex("dbo.Orden", new[] { "ClienteId" });
            DropIndex("dbo.Orden", new[] { "EmpleadoId" });
            DropTable("dbo.Producto");
            DropTable("dbo.Empleado");
            DropTable("dbo.Orden");
            DropTable("dbo.Cliente");
        }
    }
}
