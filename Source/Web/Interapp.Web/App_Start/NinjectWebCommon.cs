﻿[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Interapp.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Interapp.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Interapp.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using Common.Constants;
    using Data;
    using Data.Common;
    using Data.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Services.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(DbContext)).To(typeof(InterappDbContext));
            kernel.Bind(typeof(IInterappDbContext)).To(typeof(InterappDbContext));
            kernel.Bind(typeof(IDbRepository<>)).To(typeof(DbRepository<>));
            kernel.Bind(typeof(ICacheService)).To(typeof(HttpCacheService));

            kernel.Bind(b => b.From(Assemblies.DataServices)
                              .SelectAllClasses()
                              .BindDefaultInterface());
        }
    }
}
