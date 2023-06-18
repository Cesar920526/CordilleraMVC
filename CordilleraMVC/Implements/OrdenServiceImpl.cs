using CordilleraMVC.Models;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
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

        public OrdenServiceImpl(IOrdenRepository ordenRepository)
        {
            this.ordenRepository = ordenRepository;
        }

        public bool ActualizarOrden(ModelStateDictionary modelState)
        {
            try
            {
                ordenRepository.Guardar();
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
            throw new NotImplementedException();
        }

        public void BorrarOrden(int id)
        {
            ordenRepository.BorrarOrden(id);
        }

        public Orden BuscarPorId(int id)
        {
            return ordenRepository.BuscarOrdenPorId(id);
        }

        public void Guardar()
        {
            ordenRepository.Guardar();
        }

        public bool GuardarOrden(Orden orden, ModelStateDictionary modelState)
        {
            try
            {
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
    }
}