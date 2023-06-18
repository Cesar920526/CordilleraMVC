using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }
        [Required]
        [StringLength(70)]
        public string NombreProducto { get; set; }
        [StringLength(1000)]
        public string Descripcion { get; set; }
        [Required]
        public double Precio { get; set; }
        public virtual ICollection<Orden> Ordenes { get; set; }

    }
}