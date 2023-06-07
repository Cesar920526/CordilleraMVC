using CordilleraMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ListarClientes();
        IPagedList ListarClientesPag(int numeroPagina, int tamañoPaginas, List<Cliente> listaClientes);
        Cliente BuscarPorId(int id);
        List<Cliente> BuscarPorNombre(string nombre);
        void GuardarCliente(Cliente cliente);
        void BorrarCliente(int id);
        void ActualizarCliente(Cliente cliente);
        IEnumerable<Cliente> PorOrden(int numero);
        void Guardar();
    }
}