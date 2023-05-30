using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public interface IOrdenRepository
    {
        List<Orden> ListarOrdenes();
        List<Orden> ListarOrdenesPag(int numeroPagina, int tamañoPaginas);
        Orden BuscarOrdenPorId(int id);
        void GuardarOrden(Orden orden);
        void BorrarOrden(int id);
        void ActualizarOrden(Orden orden);
        List<Orden> OrdenDesc(int numero);
        List<Orden> PorOrden(int numero);
        void Guardar();
    }
}