using CordilleraMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CordilleraMVC.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void ActualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void BorrarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> BuscarPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public void GuardarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        public List<Usuario> ListarUsuariosPag(int numeroPagina, int tamañoPaginas)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> OrdenDesc(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> PorOrden(int numero)
        {
            throw new NotImplementedException();
        }
    }
}