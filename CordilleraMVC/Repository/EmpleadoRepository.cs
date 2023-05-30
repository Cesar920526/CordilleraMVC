using CordilleraMVC.Data;
using CordilleraMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PagedList;
using System.Web;

namespace CordilleraMVC.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository, IDisposable
    {
        private CordilleraContext cordilleraContext = new CordilleraContext();

        public void ActualizarEmpleado(Empleado empleado)
        {
            cordilleraContext.SaveChanges();
        }

        public void BorrarEmpleado(int id)
        {
            Empleado empleado = this.BuscarPorId(id);
            if(empleado != null)
            {
                cordilleraContext.Empleados.Remove(empleado);
                cordilleraContext.SaveChanges();
            }
        }

        public Empleado BuscarPorId(int id)
        {
            return cordilleraContext.Empleados.Find(id);
        }

        public List<Empleado> BuscarPorNombre(string nombre)
        {
            IEnumerable<Empleado> ListEmpleados = from e in cordilleraContext.Empleados select e;
            IEnumerable<Empleado> empleados = ListEmpleados.Where(e => e.Nombre.Contains(nombre) || e.Apellido.Contains(nombre));
            return empleados.ToList();
        }

        public void Dispose()
        {
            cordilleraContext.Dispose();
        }

        public void Guardar()
        {
            cordilleraContext.SaveChanges();
        }

        public void GuardarEmpleado(Empleado empleado)
        {
            cordilleraContext.Empleados.Add(empleado);
            cordilleraContext.SaveChanges();
        }

        public List<Empleado> ListarEmpleados()
        {
            return cordilleraContext.Empleados.ToList();
        }

        public List<Empleado> ListarEmpleadosPag(int numeroPagina, int tamañoPaginas)
        {
            IEnumerable<Empleado> ListEmpleados = from e in cordilleraContext.Empleados select e;
            return (List<Empleado>)ListEmpleados.ToList().ToPagedList(numeroPagina, tamañoPaginas);
        }

        public List<Empleado> OrdenDesc(int numero)
        {
            IEnumerable<Empleado> ListEmpleados = from e in cordilleraContext.Empleados select e;
            if(numero == 1)
            {
                ListEmpleados = ListEmpleados.OrderByDescending(e => e.Apellido);
            }
            if(numero == 2)
            {
                ListEmpleados = ListEmpleados.OrderByDescending(e => e.Cargo);
            }
            return ListEmpleados.ToList();
        }

        public List<Empleado> PorOrden(int numero)
        {
            IEnumerable<Empleado> ListEmpleados = from e in cordilleraContext.Empleados select e;
            if (numero == 1)
            {
                ListEmpleados = ListEmpleados.OrderBy(e => e.Apellido);
            }
            if (numero == 2)
            {
                ListEmpleados = ListEmpleados.OrderBy(e => e.Cargo);
            }
            return ListEmpleados.ToList();
        }
    }
}