using CordilleraMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> ListarProductos();
        IPagedList ListarProductosPag(int numeroPagina, int tamañoPaginas, List<Producto> productos);
        Producto BuscarProductoPorId(int id);
        List<Producto> BuscarProductoPorNombre(string nombre);
        void GuardarProducto(Producto producto);
        void BorrarProducto(int id);
        void ActualizarProducto(Producto producto);
        IEnumerable<Producto> PorOrden(int numero);
        void Guardar();
        IEnumerable<Producto> TodosProductos();
    }
}