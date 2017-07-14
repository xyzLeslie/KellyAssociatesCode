[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ShoppingCart.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ShoppingCart.App_Start.NinjectWebCommon), "Stop")]

namespace ShoppingCart.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ShoppingCart.Data;
    using ShoppingCart.Service;
    using Data.Repository.Interface;
    using Data.Repository;
    using Service.Services;

    public static class NinjectWebCommon
    {
        private static readonly Ninject.Web.Common.Bootstrapper bootstrapper = new Ninject.Web.Common.Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Ninject.Web.Common.Bootstrapper().Kernel);
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
        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IInventoryRepository>().To<InventoryRepository>();
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IPaymentService>().To<IPaymentService>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IEmailService>().To<EmailService>();
        }
    }
}
