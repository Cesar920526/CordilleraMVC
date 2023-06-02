using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordilleraMVC.Services
{
    public interface IEmpleadoService
    {
        IEnumerable<Empleado> ListaEmpleados();
        List<Empleado> ListarEmpleadosPag(string filtroActual, string nombreBusqueda, int? pagina);
        Empleado BuscarPorId(int id);
        List<Empleado> BuscarPorNombre(string nombre);
        bool GuardarEmpleado(Empleado empleado);
        void BorrarEmpleado(int id);
        bool ActualizarEmpleado();
        List<Empleado> PorOrden(string ordenSort);
        void Guardar();
    }
}
