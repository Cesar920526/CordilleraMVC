using CordilleraMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public interface IEmpleadoRepository
    {
        IEnumerable<Empleado> ListarEmpleados();
        IPagedList ListarEmpleadosPag(int numeroPagina, int tamañoPaginas, List<Empleado> empleados);
        Empleado BuscarPorId(int id);
        List<Empleado> BuscarPorNombre(string nombre);
        void GuardarEmpleado(Empleado empleado);
        void BorrarEmpleado(int id);
        void ActualizarEmpleado(Empleado empleado);
        IEnumerable<Empleado> PorOrden(int numero);
        void Guardar();
    }
}