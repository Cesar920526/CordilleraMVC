using CordilleraMVC.Models;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CordilleraMVC.Services
{
    public interface IEmpleadoService
    {
        List<Empleado> ListaEmpleados();
        IPagedList ListarEmpleadosPag(string filtroActual, string nombreBusqueda, int? pagina, List<Empleado> listaEmpleados);
        Empleado BuscarPorId(int id);
        List<Empleado> BuscarPorNombre(string nombre);
        bool GuardarEmpleado(Empleado empleado, ModelStateDictionary modelState);
        void BorrarEmpleado(int id);
        bool ActualizarEmpleado(ModelStateDictionary modelState);
        List<Empleado> PorOrden(string ordenSort);
        void Guardar();
        string AsignacionString(string filtroActual, string nombreBusqueda);
    }
}
