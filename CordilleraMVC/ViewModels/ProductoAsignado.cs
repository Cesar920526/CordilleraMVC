using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.ViewModels
{
    public class ProductoAsignado
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public bool Asignado { get; set; }
    }
}