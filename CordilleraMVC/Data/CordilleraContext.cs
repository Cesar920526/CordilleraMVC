using CordilleraMVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CordilleraMVC.Data
{
    public class CordilleraContext : DbContext, ICordilleraContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }

        public CordilleraContext() : base("name=CordilleraContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Producto>()
                .HasMany(p => p.Ordenes).WithMany(o => o.Productos)
                .Map(t => t.MapLeftKey("ProductoId")
                    .MapRightKey("OrdenId")
                    .ToTable("ProductoOrden"));
        }
    }
}