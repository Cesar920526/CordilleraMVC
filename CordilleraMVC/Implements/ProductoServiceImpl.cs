using CordilleraMVC.Models;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CordilleraMVC.Implements
{
    public class ProductoServiceImpl : IProductoService
    {
        private IProductoRepository productoRepository;

        public ProductoServiceImpl(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public bool ActualizarProducto(ModelStateDictionary modelState)
        {
            try
            {
                productoRepository.Guardar();
                return true;
            }
            catch (DataException)
            {
                modelState.AddModelError("", "No se pudieron guardar los cambios. Intente nuevamente, y si el error persiste contacte al administrador.");
                return false;
            }
        }

        public string AsignacionString(string filtroActual, string nombreBusqueda)
        {
            if (nombreBusqueda == null)
            {
                nombreBusqueda = filtroActual;
            }
            return nombreBusqueda;
        }

        public void BorrarProdcuto(int id)
        {
            productoRepository.BorrarProducto(id);
        }

        public Producto BuscarPorId(int id)
        {
            return productoRepository.BuscarProductoPorId(id);
        }

        public List<Producto> BuscarPorNombre(string nombre)
        {
            List<Producto> productosPorNombre = null;
            if (!String.IsNullOrEmpty(nombre))
            {
                productosPorNombre = productoRepository.BuscarProductoPorNombre(nombre);
            }
            return productosPorNombre;
        }

        public void Guardar()
        {
            productoRepository.Guardar();
        }

        public bool GuardarProducto(Producto producto, ModelStateDictionary modelState)
        {
            try
            {
                if (modelState.IsValid)
                {
                    productoRepository.GuardarProducto(producto);
                }
                return true;
            }
            catch (DataException)
            {
                modelState.AddModelError("", "No se pudieron guardar los cambios. Intente nuevamente, y si el error persiste contacte al administrador.");
                return false;
            }
        }

        public List<Producto> ListaProductos()
        {
            IEnumerable<Producto> productos = productoRepository.ListarProductos();
            return productos.ToList();
        }

        public IPagedList ListarProductosPag(string filtroActual, string nombreBusqueda, int? pagina, List<Producto> listaProductos)
        {
            int tamañoPaginas = 3;
            int numeroPaginas = (pagina ?? 1);
            if (nombreBusqueda != null)
            {
                pagina = 1;
            }
            else
            {
                this.AsignacionString(filtroActual, nombreBusqueda);
            }
            return productoRepository.ListarProductosPag(numeroPaginas, tamañoPaginas, listaProductos);
        }

        public List<Producto> PorOrden(string ordenSort)
        {
            List<Producto> lista;
            int numero;
            switch (ordenSort)
            {
                case "nombre_desc":
                    numero = 1;
                    lista = productoRepository.PorOrden(numero).ToList();
                    break;

                case "precio_desc":
                    numero = 2;
                    lista = productoRepository.PorOrden(numero).ToList();
                    break;

                case "Precio":
                    numero = 3;
                    lista = productoRepository.PorOrden(numero).ToList();
                    break;

                default:
                    numero = 4;
                    lista = productoRepository.PorOrden(numero).ToList();
                    break;
            }
            return lista;
        }
    }
}