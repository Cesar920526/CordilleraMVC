using CordilleraMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public interface IOrdenRepository
    {
        IEnumerable<Orden> ListarOrdenes();
        IPagedList<Orden> ListarOrdenesPag(int numeroPagina, int tamañoPaginas, List<Orden> ordenes);
        Orden BuscarOrdenPorId(int id);
        Orden BuscarOrdenConProductos(int id);
        void GuardarOrden(Orden orden);
        void BorrarOrden(int id);
        void ActualizarOrden(Orden orden);
        IEnumerable<Orden> PorOrden(int numero);
        void Guardar();
        IQueryable ListaDespegableEmpleado();
        IQueryable ListaDespegableCliente();
        IEnumerable<Orden> TodasOrdenes();
        HashSet<int> OrdenProductos(Orden orden); 
    }
}