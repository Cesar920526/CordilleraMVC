using CordilleraMVC.Models;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace CordilleraMVC.Implements
{
    public class EmpleadoServiceImpl : IEmpleadoService
    {
        private readonly IEmpleadoRepository empleadoRepository;

        public EmpleadoServiceImpl(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        public bool ActualizarEmpleado(ModelStateDictionary modelState)
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

        public bool GuardarEmpleado(Empleado empleado, ModelStateDictionary modelState)
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

        public List<Empleado> ListaEmpleados()
        {
            IEnumerable<Empleado> empleados = empleadoRepository.ListarEmpleados();
            return empleados.ToList();
        }

        public IPagedList ListarEmpleadosPag(string filtroActual, string nombreBusqueda, int? pagina, List<Empleado> listaEmpleados)
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
            return empleadoRepository.ListarEmpleadosPag(numeroPaginas, tamañoPaginas, listaEmpleados);
        }

        public List<Empleado> PorOrden(string ordenSort)
        {
            List<Empleado> lista;
            int numero;
            switch (ordenSort)
            {
                case "nombre_desc":
                    numero = 1;
                    lista = empleadoRepository.PorOrden(numero).ToList();
                    break;

                case "cargo_desc":
                    numero = 2;
                    lista = empleadoRepository.PorOrden(numero).ToList();
                    break;

                case "Cargo":
                    numero = 3;
                    lista = empleadoRepository.PorOrden(numero).ToList();
                    break;

                default:
                    numero = 4;
                    lista = empleadoRepository.PorOrden(numero).ToList();
                    break;
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