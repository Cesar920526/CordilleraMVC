using CordilleraMVC.Models;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CordilleraMVC.Implements
{
    public class ClienteServiceImpl : IClienteService
    {
        private IClienteRepository clienteRepository;

        public ClienteServiceImpl(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public bool ActualizarCliente(ModelStateDictionary modelState)
        {
            try
            {
                clienteRepository.Guardar();
                return true;
            }
            catch (DataException)
            {
                modelState.AddModelError("", "No se pudieron guardar los cambios. Intente nuevamente, y si el error persiste contacte al administrador.");
                return false;
            }
        }

        public string AsignacionString(string filtroActual, string nombreBusqueda)
        {
            if (nombreBusqueda == null)
            {
                nombreBusqueda = filtroActual;
            }
            return nombreBusqueda;
        }

        public void BorrarCliente(int id)
        {
            clienteRepository.BorrarCliente(id);
        }

        public Cliente BuscarPorId(int id)
        {
            return clienteRepository.BuscarPorId(id);
        }

        public List<Cliente> BuscarPorNombre(string nombre)
        {
            List<Cliente> clientePorNombre = null;
            if (!String.IsNullOrEmpty(nombre))
            {
                clientePorNombre = clienteRepository.BuscarPorNombre(nombre);
            }
            return clientePorNombre;
        }

        public void Guardar()
        {
            clienteRepository.Guardar();
        }

        public bool GuardarCliente(Cliente cliente, ModelStateDictionary modelState)
        {
            try
            {
                if (modelState.IsValid)
                {
                    clienteRepository.GuardarCliente(cliente);
                }
                return true;
            }
            catch (DataException)
            {
                modelState.AddModelError("", "No se pudieron guardar los cambios. Intente nuevamente, y si el error persiste contacte al administrador.");
                return false;
            }
        }

        public List<Cliente> ListarClientes()
        {
            IEnumerable<Cliente> clientes = clienteRepository.ListarClientes();
            return clientes.ToList();
        }

        public IPagedList ListarClientesPag(string filtroActual, string nombreBusqueda, int? pagina, List<Cliente> listaClientes)
        {
            int tamañoPaginas = 3;
            int numeroPaginas = (pagina ?? 1);
            if (nombreBusqueda != null)
            {
                pagina = 1;
            }
            else
            {
                this.AsignacionString(filtroActual, nombreBusqueda);
            }
            return clienteRepository.ListarClientesPag(numeroPaginas, tamañoPaginas, listaClientes);
        }

        public List<Cliente> PorOrden(string ordenSort)
        {
            List<Cliente> lista;
            int numero;
            switch (ordenSort)
            {
                case "nombre_desc":
                    numero = 1;
                    lista = clienteRepository.PorOrden(numero).ToList();
                    break;

                case "ciudad_desc":
                    numero = 2;
                    lista = clienteRepository.PorOrden(numero).ToList();
                    break;

                case "Ciudad":
                    numero = 3;
                    lista = clienteRepository.PorOrden(numero).ToList();
                    break;

                default:
                    numero = 4;
                    lista = clienteRepository.PorOrden(numero).ToList();
                    break;
            }
            return lista;
        }
    }
}