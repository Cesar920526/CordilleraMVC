using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CordilleraMVC.Implements
{
    public class ProductoServiceImpl : IProductoService
    {
        private ModelStateDictionary modelState;
        private IProductoRepository productoRepository;

        public ProductoServiceImpl(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }
    }
}