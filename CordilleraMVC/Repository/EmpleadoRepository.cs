using CordilleraMVC.Data;
using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace CordilleraMVC.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private CordilleraContext cordilleraContext;

        public EmpleadoRepository(CordilleraContext cordilleraContext)
        {
            this.cordilleraContext = cordilleraContext;
        }

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

        public void Guardar()
        {
            cordilleraContext.SaveChanges();
        }

        public void GuardarEmpleado(Empleado empleado)
        {
            cordilleraContext.Empleados.Add(empleado);
            cordilleraContext.SaveChanges();
        }

        public IEnumerable<Empleado> ListarEmpleados()
        {
            return cordilleraContext.Empleados;
        }

        public IPagedList ListarEmpleadosPag(int numeroPagina, int tamañoPaginas, List<Empleado> listaEmpleados)
        {
            IPagedList pagedList = listaEmpleados.ToPagedList(numeroPagina, tamañoPaginas);
            return pagedList;
        }

        public IEnumerable<Empleado> PorOrden(int numero)
        {
            IEnumerable<Empleado> ListEmpleados = from e in cordilleraContext.Empleados select e;
            if(numero == 1)
            {
                ListEmpleados = ListEmpleados.OrderByDescending(e => e.Apellido);
            }
            else if(numero == 2)
            {
                ListEmpleados = ListEmpleados.OrderByDescending(e => e.Cargo);
            }
            else if(numero == 3)
            {
                ListEmpleados = ListEmpleados.OrderBy(e => e.Cargo);
            }
            else if(numero == 4)
            {
                ListEmpleados = ListEmpleados.OrderBy(e => e.Apellido);
            }
            return ListEmpleados;
        }
    }
}