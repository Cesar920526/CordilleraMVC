using CordilleraMVC.Data;
using CordilleraMVC.Implements;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Lifetime;

namespace CordilleraMVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            //Context
            container.RegisterType<DbContext, CordilleraContext>(new HierarchicalLifetimeManager());
            //Repository
            container.RegisterType<IEmpleadoRepository, EmpleadoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClienteRepository, ClienteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductoRepository, ProductoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrdenRepository, OrdenRepository>(new HierarchicalLifetimeManager());
            //Service
            container.RegisterType<IEmpleadoService, EmpleadoServiceImpl>(new HierarchicalLifetimeManager());
            container.RegisterType<IClienteService, ClienteServiceImpl>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductoService, ProductoServiceImpl>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrdenService, OrdenServiceImpl>(new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}