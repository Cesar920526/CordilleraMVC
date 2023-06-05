using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CordilleraMVC.Services
{
    public interface IEmpleadoService
    {
        List<Empleado> ListaEmpleados();
        List<Empleado> ListarEmpleadosPag(string filtroActual, string nombreBusqueda, int? pagina);
        Empleado BuscarPorId(int id);
        List<Empleado> BuscarPorNombre(string nombre);
        bool GuardarEmpleado(Empleado empleado, ModelStateDictionary modelState);
        void BorrarEmpleado(int id);
        bool ActualizarEmpleado(ModelStateDictionary modelState);
        List<Empleado> PorOrden(string ordenSort);
        void Guardar();
    }
}
