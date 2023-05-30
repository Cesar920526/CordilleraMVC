using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public interface IProductoRepository
    {
        List<Producto> ListarProductos();
        List<Producto> ListarProductosPag(int numeroPagina, int tamañoPaginas);
        Producto BuscarProductoPorId(int id);
        List<Producto> BuscarProductoPorNombre(string nombre);
        void GuardarProducto(Producto producto);
        void BorrarProducto(int id);
        void ActualizarProducto(Producto producto);
        List<Producto> OrdenDesc(int numero);
        List<Producto> PorOrden(int numero);
        void Save();
    }
}