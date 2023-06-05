using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public class ClienteRepository : IClienteRepository, IDisposable
    {
        public void ActualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public void GuardarCliente(Cliente cliente)
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