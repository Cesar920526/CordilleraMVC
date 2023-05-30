using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public interface IEmpleadoRepository
    {
        List<Empleado> ListarEmpleados();
        List<Empleado> ListarEmpleadosPag(int numeroPagina, int tamañoPaginas);
        Empleado BuscarPorId(int id);
        List<Empleado> BuscarPorNombre(string nombre);
        void GuardarEmpleado(Empleado empleado);
        void BorrarEmpleado(int id);
        void ActualizarEmpleado(Empleado empleado);
        List<Empleado> OrdenDesc(int numero);
        List<Empleado> PorOrden(int numero);
        void Guardar();

    }
}