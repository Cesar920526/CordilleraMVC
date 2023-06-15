using CordilleraMVC.Models;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            throw new NotImplementedException();
        }

        public string AsignacionString(string filtroActual, string nombreBusqueda)
        {
            throw new NotImplementedException();
        }

        public void BorrarOrden(int id)
        {
            throw new NotImplementedException();
        }

        public Orden BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public bool GuardarOrden(Orden orden, ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
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