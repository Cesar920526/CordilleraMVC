using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordilleraMVC.Services
{
    public interface IClienteService
    {
        List<Cliente> ListarClientes();
        List<Cliente> ListarClientesPag(int numeroPagina, int tamañoPaginas);
        Cliente BuscarPorId(int id);
        List<Cliente> BuscarPorNombre(string nombre);
        bool GuardarCliente(Cliente cliente);
        void BorrarCliente(int id);
        bool ActualizarCliente(Cliente cliente);
        List<Cliente> OrdenDesc(int numero);
        List<Cliente> PorOrden(int numero);
        void Guardar();
    }
}
