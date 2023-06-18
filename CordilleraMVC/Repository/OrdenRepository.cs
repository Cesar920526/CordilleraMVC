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
            cordilleraContext.SaveChanges();
        }

        public void BorrarOrden(int id)
        {
            throw new NotImplementedException();
        }

        public Orden BuscarOrdenPorId(int id)
        {
            return cordilleraContext.Ordenes.Find(id);
        }

        public void Guardar()
        {
            cordilleraContext.SaveChanges();
        }

        public void GuardarOrden(Orden orden)
        {
            cordilleraContext.Ordenes.Add(orden);
            cordilleraContext.SaveChanges();
        }

        public IQueryable ListaDespegableCliente()
        {
            IQueryable clientes = from c in cordilleraContext.Clientes
                          orderby c.Nombre
                          select c;
            return clientes;
        }

        public IQueryable ListaDespegableEmpleado()
        {
            IQueryable empleados = from e in cordilleraContext.Empleados
                          orderby e.Nombre
                          select e;
            return empleados;
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