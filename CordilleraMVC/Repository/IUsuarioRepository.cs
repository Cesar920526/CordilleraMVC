using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarUsuarios();
        List<Usuario> ListarUsuariosPag(int numeroPagina, int tamañoPaginas);
        Usuario BuscarPorId(int id);
        List<Usuario> BuscarPorNombre(string nombre);
        void GuardarUsuario(Usuario usuario);
        void BorrarUsuario(int id);
        void ActualizarUsuario(Usuario usuario);
        List<Usuario> OrdenDesc(int numero);
        List<Usuario> PorOrden(int numero);
        void Guardar();
    }
}