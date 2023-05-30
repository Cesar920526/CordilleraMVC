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
        List<Empleado> ListarEmpleados();
        List<Empleado> ListarEmpleadosPag(int numeroPagina, int tamañoPaginas);
        Empleado BuscarPorId(int id);
        List<Empleado> BuscarPorNombre(string nombre);
        bool GuardarEmpleado(Empleado empleado);
        void BorrarEmpleado(int id);
        bool ActualizarEmpleado(Empleado empleado);
        List<Empleado> OrdenDesc(int numero);
        List<Empleado> PorOrden(int numero);
        void Guardar();
    }
}
