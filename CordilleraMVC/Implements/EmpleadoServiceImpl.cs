using CordilleraMVC.Models;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CordilleraMVC.Implements
{
    public class EmpleadoServiceImpl : IEmpleadoService
    {
        private ModelStateDictionary modelState;
        private IEmpleadoRepository empleadoRepository;

        public EmpleadoServiceImpl(ModelStateDictionary modelState, IEmpleadoRepository empleadoRepository)
        {
            this.modelState = modelState;
            this.empleadoRepository = empleadoRepository;
        }

        public bool ActualizarEmpleado()
        {
            try
            {
                empleadoRepository.Guardar();
                return true;
            }
            catch (DataException)
            {
                modelState.AddModelError("", "No se pudieron guardar los cambios. Intente nuevamente, y si el error persiste contacte al administrador.");
                return false;
            }            
        }

        public void BorrarEmpleado(int id)
        {
            empleadoRepository.BorrarEmpleado(id);
        }

        public Empleado BuscarPorId(int id)
        {
            return empleadoRepository.BuscarPorId(id);
        }

        public List<Empleado> BuscarPorNombre(string nombre)
        {
            List<Empleado> empleadosPorNombre = null;
            if (!String.IsNullOrEmpty(nombre))
            {
                empleadosPorNombre = empleadoRepository.BuscarPorNombre(nombre);
            }
            return empleadosPorNombre;
        }

        public void Guardar()
        {
            empleadoRepository.Guardar();
        }

        public bool GuardarEmpleado(Empleado empleado)
        {
            try
            {
                if (modelState.IsValid)
                {
                    empleadoRepository.GuardarEmpleado(empleado);
                }
                return true;
            }
            catch (DataException)
            {
                modelState.AddModelError("", "No se pudieron guardar los cambios. Intente nuevamente, y si el error persiste contacte al administrador.");
                return false;
            }
        }

        public IEnumerable<Empleado> ListaEmpleados()
        {
            return empleadoRepository.ListarEmpleados();
        }

        public List<Empleado> ListarEmpleadosPag(string filtroActual, string nombreBusqueda, int? pagina)
        {
            int tamañoPaginas = 3;
            int numeroPaginas = (pagina ?? 1);
            if(nombreBusqueda != null)
            {
                pagina = 1;
            }
            else
            {
                this.AsignacionString(filtroActual, nombreBusqueda);
            }
            return empleadoRepository.ListarEmpleadosPag(numeroPaginas, tamañoPaginas);
        }

        public List<Empleado> PorOrden(string ordenSort)
        {
            List<Empleado> lista;
            int numero;
            if (ordenSort.Equals("nombre_desc"))
            {
                numero = 1;
                lista = empleadoRepository.PorOrden(numero);
            }
            else if (ordenSort.Equals("cargo_desc"))
            {
                numero = 2;
                lista = empleadoRepository.PorOrden(numero);
            }
            else if (ordenSort.Equals("Cargo"))
            {
                numero = 3;
                lista = empleadoRepository.PorOrden(numero);
            }
            else
            {
                numero = 4;
                lista = empleadoRepository.PorOrden(numero);
            }
            return lista;
        }

        public string AsignacionString(string filtroActual, string nombreBusqueda)
        {
            if(nombreBusqueda == null)
            {
                nombreBusqueda = filtroActual;
            }
            return nombreBusqueda;
        }

        /*private bool TryUpdateModel(Empleado empleado, string valor, string[] datosEmpleado)
        {
            return TryUpdateModel(empleado, valor, datosEmpleado);
        }*/
    }
}