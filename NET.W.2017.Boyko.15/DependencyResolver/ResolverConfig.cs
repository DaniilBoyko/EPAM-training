using System.Data.Entity;
using BLL.Interfaces.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interfaces.Repository;
using Ninject;
using ORM;

namespace DependencyResolver
{
    /// <summary>
    /// Class for solve dependencies.
    /// </summary>
    public static class ResolverConfig
    {
        /// <summary>
        /// Configure console dependencies.
        /// </summary>
        /// <param name="kernel">configuration kernel</param>
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        /// <summary>
        /// Configure kernel.
        /// </summary>
        /// <param name="kernel">configuration</param>
        /// <param name="isWeb">is web</param>
        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (!isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<EntityModel>().InSingletonScope();
            }

            kernel.Bind<IAccountService>().To<BankService>();
            kernel.Bind<IAccountRepository>().To<AccountRepository>();
        }
    }
}
