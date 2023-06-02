using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Data
{
    public interface ICordilleraContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Empleado> Empleados { get; set; }
        DbSet<Producto> Productos { get; set; }
        DbSet<Orden> Ordenes { get; set; }
    }
}