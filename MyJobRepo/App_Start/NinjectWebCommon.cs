[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyJobRepo.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MyJobRepo.App_Start.NinjectWebCommon), "Stop")]

namespace MyJobRepo.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using DataAccess;
    using Ninject;
    using Ninject.Web.Common;
    using MyJobRepo.Models;
    using AutoMapper;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                // webAPI
                GlobalConfiguration.Configuration.DependencyResolver = new WebApiContrib.IoC.Ninject.NinjectResolver(kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// Ninject takes care of injecting dependencies for us.
        /// So when we need a Repository, we simply create a constructor that takes an IRepository and a Repository will be created for us.
        /// And because Repository in turn has a dependency on MyJobRepo, that will be created for us.
        /// And in the constructor for the Repository, that will be assigned to the private member variable.
        /// InRequestScope() makes it a singleton. That is, when we're asked for a Repository we always want the same one if it already exists.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepository>().To<Repository>().InRequestScope();
            kernel.Bind<MyJobRepo_DataContext>().To<MyJobRepo_DataContext>();

            kernel.Bind<IMapper>().ToMethod(context =>
            {
                var automapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MyJobRepo_MappingProfile>();
                });
                return automapperConfiguration.CreateMapper(); ;
            }).InSingletonScope();
        }        
    }
}
