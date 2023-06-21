using CordilleraMVC.Models;
using CordilleraMVC.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CordilleraMVC.Services
{
    public interface IOrdenService
    {
        List<Orden> ListaOrdenes();
        IPagedList ListarOrdenesPag(string filtroActual, string nombreBusqueda, int? pagina, List<Orden> ordenes);
        Orden BuscarPorId(int id);
        Orden BuscarConProductos(int id);
        bool GuardarOrden(Orden orden, ModelStateDictionary modelState, string[] productosSeleccionados);
        void BorrarOrden(int id);
        bool ActualizarOrden(string[] productosSeleccionados, Orden orden, ModelStateDictionary modelState);
        List<Orden> PorOrden(string ordenSort);
        void Guardar();
        string AsignacionString(string filtroActual, string nombreBusqueda);
        SelectList ListaDespegableEmpleado(object empleadoSeleccionado = null);
        SelectList ListaDespegableCliente(object empleadoSeleccionado = null);
        List<ProductoAsignado> TraerDatosProductos(Orden orden);
    }
}
