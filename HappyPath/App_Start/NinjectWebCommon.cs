[assembly: WebActivator.PreApplicationStartMethod(typeof(HappyPath.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(HappyPath.App_Start.NinjectWebCommon), "Stop")]

namespace HappyPath.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using HappyPath.App_Start.Infrustructure;
    using Ninject.Extensions.Conventions;
    using AutoMapper;
    using HappyPath.Service.Data.Context;
using System.Collections.Generic;
    using HappyPath.Service.Maps;

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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            // Set Web API Resolver
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var namespaces = new string[] {
                "HappyPath.*"
            };

            kernel.Bind(x => x
                .FromAssembliesMatching(namespaces)
                .SelectAllClasses()
                .BindAllInterfaces()
            );

            kernel.Rebind<IMappingEngine>().ToMethod(x => Mapper.Engine);

            kernel.Rebind<IHappyPathSession>().To<HappyPathSession>()
                .InRequestScope();

            AutoMapperConfiguration.Configure(kernel);
        }
    }
}
