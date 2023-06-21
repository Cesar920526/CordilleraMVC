using CordilleraMVC.Data;
using CordilleraMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private CordilleraContext cordilleraContext;

        public ProductoRepository(CordilleraContext cordilleraContext)
        {
            this.cordilleraContext = cordilleraContext;
        }   

        public void ActualizarProducto(Producto producto)
        {
            cordilleraContext.SaveChanges();
        }

        public void BorrarProducto(int id)
        {
            Producto producto = this.BuscarProductoPorId(id);
            if (producto != null)
            {
                cordilleraContext.Productos.Remove(producto);
                cordilleraContext.SaveChanges();
            }
        }

        public Producto BuscarProductoPorId(int id)
        {
            return cordilleraContext.Productos.Find(id);
        }

        public List<Producto> BuscarProductoPorNombre(string nombre)
        {
            IEnumerable<Producto> listaProductos = from p in cordilleraContext.Productos select p;
            IEnumerable<Producto> productos = listaProductos.Where(p => p.NombreProducto.Contains(nombre));
            return productos.ToList();
        }

        public void GuardarProducto(Producto producto)
        {
            cordilleraContext.Productos.Add(producto);
            cordilleraContext.SaveChanges();
        }

        public IEnumerable<Producto> ListarProductos()
        {
            return cordilleraContext.Productos;
        }

        public IPagedList ListarProductosPag(int numeroPagina, int tamañoPaginas, List<Producto> productos)
        {
            IPagedList pagedList = productos.ToPagedList(numeroPagina, tamañoPaginas);
            return pagedList;
        }

        public IEnumerable<Producto> PorOrden(int numero)
        {
            IEnumerable<Producto> listaProductos = from p in cordilleraContext.Productos select p;
            if (numero == 1)
            {
                listaProductos = listaProductos.OrderByDescending(p => p.NombreProducto);
            }
            else if (numero == 2)
            {
                listaProductos = listaProductos.OrderByDescending(p => p.Precio);
            }
            else if (numero == 3)
            {
                listaProductos = listaProductos.OrderBy(p => p.Precio);
            }
            else if (numero == 4)
            {
                listaProductos = listaProductos.OrderBy(p => p.NombreProducto);
            }
            return listaProductos;
        }

        public void Guardar()
        {
            cordilleraContext.SaveChanges();
        }

        public IEnumerable<Producto> TodosProductos()
        {
            return cordilleraContext.Productos;
        }
    }
}