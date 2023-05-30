using CordilleraMVC.Models;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using System;
using System.Collections.Generic;
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

        public bool ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                empleadoRepository.ActualizarEmpleado(empleado);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void BorrarEmpleado(int id)
        {
            throw new NotImplementedException();
        }

        public Empleado BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> BuscarPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public bool GuardarEmpleado(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> ListarEmpleados()
        {
            throw new NotImplementedException();
        }

        public List<Empleado> ListarEmpleadosPag(int numeroPagina, int tamañoPaginas)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> OrdenDesc(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> PorOrden(int numero)
        {
            throw new NotImplementedException();
        }
    }
}