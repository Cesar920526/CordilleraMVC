using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CordilleraMVC.Implements
{
    public class UsuarioServiceImpl : IUsuarioService
    {
        private ModelStateDictionary modelState;
        private IUsuarioRepository usuarioRepository;

        public UsuarioServiceImpl(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
    }
}