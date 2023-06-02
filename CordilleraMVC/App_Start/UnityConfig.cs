using CordilleraMVC.Data;
using CordilleraMVC.Implements;
using CordilleraMVC.Repository;
using CordilleraMVC.Services;
using System;
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
        }

        public static void RegisterDependencies()
        {
            UnityContainer unityContainer = new UnityContainer();

            //Repository
            unityContainer.RegisterType<IEmpleadoRepository, EmpleadoRepository>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IClienteRepository, ClienteRepository>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IProductoRepository, ProductoRepository>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IOrdenRepository, OrdenRepository>(new HierarchicalLifetimeManager());
            //Service
            unityContainer.RegisterType<IEmpleadoService, EmpleadoServiceImpl>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IClienteService, ClienteServiceImpl>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IProductoService, ProductoServiceImpl>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<IOrdenService, OrdenServiceImpl>(new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(unityContainer));
        }
    }
}