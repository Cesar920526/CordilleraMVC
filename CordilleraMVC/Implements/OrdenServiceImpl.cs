﻿using CordilleraMVC.Models;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using CordilleraMVC.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace CordilleraMVC.Implements
{
    public class OrdenServiceImpl : IOrdenService
    {
        private IOrdenRepository ordenRepository;
        private IProductoService productoService;

        public OrdenServiceImpl(IOrdenRepository ordenRepository, IProductoService productoService)
        {
            this.ordenRepository = ordenRepository;
            this.productoService = productoService;
        }

        public bool ActualizarOrden(string[] productosSeleccionados, Orden orden, ModelStateDictionary modelState)
        {
            try
            {
                ActualizaOrdenProducto(productosSeleccionados, orden);
                ordenRepository.Guardar();
                return true;
            }
            catch (DataException)
            {
                modelState.AddModelError("", "No se pudieron guardar los cambios. Intente nuevamente, y si el error persiste contacte al administrador.");
                return false;
            }
        }

        private void ActualizaOrdenProducto(string[] productosSeleccionados, Orden orden)
        {
            if (productosSeleccionados == null)
            {
                orden.Productos = new List<Producto>();
                return;
            }

            HashSet<string> psHS = new HashSet<string>(productosSeleccionados);
            HashSet<int> ordenProductos = ordenRepository.OrdenProductos(orden);
            List<Producto> productos = productoService.ListaProductos();
            foreach (Producto p in productos)
            {
                if (psHS.Contains(p.ProductoId.ToString()))
                {
                    if (!ordenProductos.Contains(p.ProductoId))
                    {
                        orden.Productos.Add(p);
                    }
                }
                else
                {
                    if (ordenProductos.Contains(p.ProductoId))
                    {
                        orden.Productos.Remove(p);
                    }
                }
            }
        }

        public string AsignacionString(string filtroActual, string nombreBusqueda)
        {
            throw new NotImplementedException();
        }

        public void BorrarOrden(int id)
        {
            ordenRepository.BorrarOrden(id);
        }

        public Orden BuscarConProductos(int id)
        {
            return ordenRepository.BuscarOrdenConProductos(id);
        }

        public Orden BuscarPorId(int id)
        {
            return ordenRepository.BuscarOrdenPorId(id);
        }

        public void Guardar()
        {
            ordenRepository.Guardar();
        }

        public bool GuardarOrden(Orden orden, ModelStateDictionary modelState, string[] productosSeleccionados)
        {
            try
            {
                if(productosSeleccionados != null)
                {
                    orden.Productos = new List<Producto>();
                    foreach(string producto in productosSeleccionados)
                    {
                        Producto productos = productoService.BuscarPorId(int.Parse(producto));
                        orden.Productos.Add(productos);
                    }
                }
                if (modelState.IsValid)
                {
                    ordenRepository.GuardarOrden(orden);
                }
                return true;
            }
            catch (RetryLimitExceededException)
            {
                modelState.AddModelError("", "No se pudieron guardar los cambios. Intente nuevamente, y si el error persiste contacte al administrador.");
                return false;
            }
        }

        public SelectList ListaDespegableCliente(object clienteSeleccionado = null)
        {
            IQueryable listaClientes = ordenRepository.ListaDespegableCliente();
            SelectList clienteID = new SelectList(listaClientes, "ClienteId", "Nombre", clienteSeleccionado);
            return clienteID;
        }

        public SelectList ListaDespegableEmpleado(object empleadoSeleccionado = null)
        {
            IQueryable listaEmpleados = ordenRepository.ListaDespegableEmpleado();
            SelectList empleadoID = new SelectList(listaEmpleados, "EmpleadoId", "Nombre", empleadoSeleccionado);
            return empleadoID;
        }

        public List<Orden> ListaOrdenes()
        {
            IEnumerable<Orden> ordenes = ordenRepository.ListarOrdenes();
            return ordenes.ToList();
        }

        public IPagedList ListarOrdenesPag(string filtroActual, string nombreBusqueda, int? pagina, List<Orden> ordenes)
        {
            throw new NotImplementedException();
        }

        public List<Orden> PorOrden(string ordenSort)
        {
            throw new NotImplementedException();
        }

        public List<ProductoAsignado> TraerDatosProductos(Orden orden)
        {
            List<Producto> productosTodos = productoService.ListaProductos();
            HashSet<int> ordenProductos = new HashSet<int>(ordenRepository.OrdenProductos(orden));
            List<ProductoAsignado> viewModel = new List<ProductoAsignado>();
            foreach(Producto p in productosTodos)
            {
                viewModel.Add(new ProductoAsignado
                {
                    ProductoId = p.ProductoId,
                    NombreProducto = p.NombreProducto,
                    Asignado = ordenProductos.Contains(p.ProductoId)
                });
            }
            return viewModel;
        }
    }
}