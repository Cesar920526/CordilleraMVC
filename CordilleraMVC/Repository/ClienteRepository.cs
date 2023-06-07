using CordilleraMVC.Data;
using CordilleraMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private CordilleraContext cordilleraContext;

        public ClienteRepository(CordilleraContext cordilleraContext)
        {
            this.cordilleraContext = cordilleraContext;
        }

        public void ActualizarCliente(Cliente cliente)
        {
            cordilleraContext.SaveChanges();
        }

        public void BorrarCliente(int id)
        {
            Cliente cliente = this.BuscarPorId(id);
            if (cliente != null)
            {
                cordilleraContext.Clientes.Remove(cliente);
                cordilleraContext.SaveChanges();
            }
        }

        public Cliente BuscarPorId(int id)
        {
            return cordilleraContext.Clientes.Find(id);
        }

        public List<Cliente> BuscarPorNombre(string nombre)
        {
            IEnumerable<Cliente> ListaClientes = from c in cordilleraContext.Clientes select c;
            IEnumerable<Cliente> clientes = ListaClientes.Where(c => c.Nombre.Contains(nombre) || c.Apellido.Contains(nombre));
            return clientes.ToList();
        }

        public void Guardar()
        {
            cordilleraContext.SaveChanges();
        }

        public void GuardarCliente(Cliente cliente)
        {
            cordilleraContext.Clientes.Add(cliente);
            cordilleraContext.SaveChanges();
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return cordilleraContext.Clientes;
        }

        public IPagedList ListarClientesPag(int numeroPagina, int tamañoPaginas, List<Cliente> listaClientes)
        {
            IPagedList pagedList = listaClientes.ToPagedList(numeroPagina, tamañoPaginas);
            return pagedList;
        }

        public IEnumerable<Cliente> PorOrden(int numero)
        {
            IEnumerable<Cliente> listaClientes = from c in cordilleraContext.Clientes select c;
            if (numero == 1)
            {
                listaClientes = listaClientes.OrderByDescending(c => c.Apellido);
            }
            else if (numero == 2)
            {
                listaClientes = listaClientes.OrderByDescending(c => c.Ciudad);
            }
            else if (numero == 3)
            {
                listaClientes = listaClientes.OrderBy(c => c.Ciudad);
            }
            else if (numero == 4)
            {
                listaClientes = listaClientes.OrderBy(c => c.Apellido);
            }
            return listaClientes;
        }
    }
}