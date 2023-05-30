using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Data
{
    public class CordilleraContext : DbContext, ICordilleraContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }

        public CordilleraContext() : base("name=CordilleraContext") { }
    }
}