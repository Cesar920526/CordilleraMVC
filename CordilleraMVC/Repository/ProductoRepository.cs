using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public class ProductoRepository : IProductoRepository, IDisposable
    {
        public void ActualizarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public void BorrarProducto(int id)
        {
            throw new NotImplementedException();
        }

        public Producto BuscarProductoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> BuscarProductoPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void GuardarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public List<Producto> ListarProductos()
        {
            throw new NotImplementedException();
        }

        public List<Producto> ListarProductosPag(int numeroPagina, int tamañoPaginas)
        {
            throw new NotImplementedException();
        }

        public List<Producto> OrdenDesc(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Producto> PorOrden(int numero)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}