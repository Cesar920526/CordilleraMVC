using CordilleraMVC.Models;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CordilleraMVC.Services
{
    public interface IClienteService
    {
        List<Cliente> ListarClientes();
        IPagedList ListarClientesPag(string filtroActual, string nombreBusqueda, int? pagina, List<Cliente> listaClientes);
        Cliente BuscarPorId(int id);
        List<Cliente> BuscarPorNombre(string nombre);
        bool GuardarCliente(Cliente cliente, ModelStateDictionary modelState);
        void BorrarCliente(int id);
        bool ActualizarCliente(ModelStateDictionary modelState);
        List<Cliente> PorOrden(string ordenSort);
        void Guardar();
        string AsignacionString(string filtroActual, string nombreBusqueda);
    }
}
