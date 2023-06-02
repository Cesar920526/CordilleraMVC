using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CordilleraMVC.Implements
{
    public class OrdenServiceImpl : IOrdenService
    {
        private ModelStateDictionary modelState;
        private IOrdenRepository ordenRepository;

        public OrdenServiceImpl(ModelStateDictionary modelState, IOrdenRepository ordenRepository)
        {
            this.modelState = modelState;
            this.ordenRepository = ordenRepository;
        }
    }
}