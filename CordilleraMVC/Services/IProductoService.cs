using CordilleraMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CordilleraMVC.Services
{
    public interface IProductoService
    {
        List<Producto> ListaProductos();
        IPagedList ListarProductosPag(string filtroActual, string nombreBusqueda, int? pagina, List<Producto> listaProductos);
        Producto BuscarPorId(int id);
        List<Producto> BuscarPorNombre(string nombre);
        bool GuardarProducto(Producto producto, ModelStateDictionary modelState);
        void BorrarProdcuto(int id);
        bool ActualizarProducto(ModelStateDictionary modelState);
        List<Producto> PorOrden(string ordenSort);
        void Guardar();
        string AsignacionString(string filtroActual, string nombreBusqueda);
    }
}
