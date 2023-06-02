using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public interface IClienteRepository
    {
        List<Cliente> ListarClientes();
        List<Cliente> ListarClientesPag(int numeroPagina, int tamañoPaginas);
        Cliente BuscarPorId(int id);
        List<Cliente> BuscarPorNombre(string nombre);
        void GuardarCliente(Cliente cliente);
        void BorrarCliente(int id);
        void ActualizarCliente(Cliente cliente);
        List<Cliente> OrdenDesc(int numero);
        List<Cliente> PorOrden(int numero);
        void Guardar();
    }
}