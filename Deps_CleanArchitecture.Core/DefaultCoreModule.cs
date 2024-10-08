using Autofac;
using Deps_CleanArchitecture.Core.Interfaces;

namespace Deps_CleanArchitecture.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CepimService>().As<ICepimService>().InstancePerLifetimeScope();
        }
    }
}
