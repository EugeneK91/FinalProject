using System.Data.Entity;
using BLL;
using BLL.Concrete;
using BLL.Interface;
using DAL;
using DAL.Concreate;
using DAL.Concrete;
using DAL.Interface;
using Ninject;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }
        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<EntityContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<EntityContext>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();

            kernel.Bind<IAudioFileRepository>().To<AudioFileRepository>();
            kernel.Bind<IAudioFileService>().To<AudioFileService>();

            kernel.Bind<IAudioRatingRepository>().To<AudioRatingRepository>();
            kernel.Bind<IAudioRatingService>().To<AudioRatingService>();

        }
    }
}
