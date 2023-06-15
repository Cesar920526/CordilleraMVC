using CordilleraMVC.Data;
using CordilleraMVC.Models;
using System.Data.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public class OrdenRepository : IOrdenRepository
    {
        private CordilleraContext cordilleraContext;

        public OrdenRepository(CordilleraContext cordilleraContext)
        {
            this.cordilleraContext = cordilleraContext;
        }

        public void ActualizarOrden(Orden orden)
        {
            throw new NotImplementedException();
        }

        public void BorrarOrden(int id)
        {
            throw new NotImplementedException();
        }

        public Orden BuscarOrdenPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public void GuardarOrden(Orden orden)
        {
            throw new NotImplementedException();
        }

        public void ListaDespegableCliente()
        {
            var ordenes = from c in cordilleraContext.Clientes
                          orderby c.Nombre
                          select c;
        }

        public void ListaDespegableEmpleado()
        {
            var ordenes = from o in cordilleraContext.Empleados
                                         orderby o.Nombre
                                         select o;
        }

        public IEnumerable<Orden> ListarOrdenes()
        {
            IEnumerable<Orden> ordenes = cordilleraContext.Ordenes.Include(o => o.Cliente).Include(o => o.Empleado);
            return ordenes;
        }

        public IPagedList<Orden> ListarOrdenesPag(int numeroPagina, int tamañoPaginas, List<Orden> ordenes)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orden> PorOrden(int numero)
        {
            throw new NotImplementedException();
        }
    }
}