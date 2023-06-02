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
    public class ClienteServiceImpl : IClienteService
    {
        private ModelStateDictionary modelState;
        private IClienteRepository usuarioRepository;

        public ClienteServiceImpl(ModelStateDictionary modelState, IClienteRepository usuarioRepository)
        {
            this.modelState = modelState;
            this.usuarioRepository = usuarioRepository;
        }

        public bool ActualizarCliente(Cliente usuario)
        {
            try
            {
                usuarioRepository.ActualizarCliente(usuario);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void BorrarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> BuscarPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public bool GuardarCliente(Cliente usuario)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarClientes()
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarClientesPag(int numeroPagina, int tamañoPaginas)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> OrdenDesc(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> PorOrden(int numero)
        {
            throw new NotImplementedException();
        }
    }
}